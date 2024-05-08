using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text;
using Zy.Shared.Constraint;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.YitterHelper.Register;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Zy.Shared.Service.Services;
using Microsoft.IdentityModel.Tokens;
using Zy.Shared.Cache.Register;
using Zy.Shared.DistributedLock.Register;
using Zy.Shared.SkyApm.Register;
using SwaggerDoc.Extensions;

namespace Zy.Shared.WebApi.Register
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddZySharedService(this IServiceCollection services,ServiceInfo serviceInfo,IConfiguration config)
        {
            services.AddSingleton(serviceInfo);
            services.AddSingleton(typeof(Lazy<>));
            services.AddDistributeLockService();
            services.AddScoped(typeof(ZyUserContext));           
            services.AddZyCorsServices(serviceInfo,config);
            
            services.AddZyJwtService(config);
            services.AddCache();
            services.AddYitter();
            services.AddControllers();
            services.AddZySwaggerService(serviceInfo);
            services.AddSkyApm(serviceInfo);
            return services;
        }
      
        /// <summary>
        /// 注册Cors
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyCorsServices(this IServiceCollection services, ServiceInfo serviceInfo, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(serviceInfo.CorsPolicy,
                    builder =>
                    {
                        var origins = config.GetSection("Cors:Urls").Get<string[]>();
                        builder.WithOrigins(origins)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
            return services;
        }

        /// <summary>
        /// 注入JWT
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyJwtService(this IServiceCollection services, IConfiguration config)
        {
            //注入jwt
            services.AddScoped<GenerateJwtService>();
            services.Configure<JwtConfig>(config.GetSection("JwtConfig"));
            var jwtConfig = new JwtConfig();
            config.Bind("JwtConfig", jwtConfig);
            services
                .AddAuthorization()
                .AddAuthentication(option =>
                {
                    //认证middleware配置
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Token颁发机构
                        ValidIssuer = jwtConfig.Issuer,
                        //颁发给谁
                        ValidAudience = jwtConfig.Audience,
                        //这里的key要进行加密
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey)),
                        //是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        ValidateLifetime = true,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && path.HasValue &&
                                (path.Value.Contains("/chatHub")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            //Token expired
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            else if (context.Exception.GetType() == typeof(SecurityTokenInvalidLifetimeException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            return services;
        }

        /// <summary>
        /// 注入Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddZySwaggerService(this IServiceCollection services, ServiceInfo serviceInfo)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           services.AddEndpointsApiExplorer();
            services.AddSwaggerDoc();//生成MarkDown文档 https://{IP}:{Port}/doc?swaggerVersion=v1
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc($"Zy.{serviceInfo.ShortName}", new OpenApiInfo { Title = $"Zy.{serviceInfo.ShortName}", Version = $"v1" });
                
                //添加安全定义
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "请输入token,格式为 Bearer xxxxxxxx（注意中间必须有空格）",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                //添加安全要求
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
               {
                        new OpenApiSecurityScheme{
                            Reference =new OpenApiReference{
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                            }
                        },Array.Empty<string>()
                }
            });
                c.IncludeXmlComments("doc.xml", true);
            });
            return services;
        }
    }
}
