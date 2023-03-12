using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Nacos.AspNetCore.V2;
using Nacos.V2;
using Nacos.V2.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Registrar;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Options;

namespace zy.webcore.Share.WebApi.Register
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddZyWebApi(this WebApplicationBuilder builder, IServiceInfo serviceInfo)
        {
            // Add services to the container.
            if (builder.Environment.IsDevelopment())//仅开发环境加载本地配置，其他环境走Consul配置中心 Modify by garfield 20221019
            {
                builder.Configuration.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.shared.{builder.Environment.EnvironmentName}.json", true, true);
            }

            builder.Configuration.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.{builder.Environment.EnvironmentName}.json", true, true);
            // 注册服务到Nacos
            builder.Services.AddNacosAspNet(builder.Configuration, "NacosConfig"); //默认节点Nacos
            // 添加配置中心
            builder.Host.ConfigureAppConfiguration((context, b) =>
            {
                b.AddNacosV2Configuration(builder.Configuration.GetSection("NacosConfig"));
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
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
                c.IncludeXmlComments("/Swagger/doc.xml", true);
            });
            // 以下是加入了JWT身份认证
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                var jwtConfig = builder.Configuration.GetSection("JWT").Get<JwtOption>();
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
                };
            });
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy(serviceInfo.CorsPolicy, opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            //ServiceCollection
            builder.Services.AddSingleton(builder);
            builder.Services.ReplaceConfiguration(builder.Configuration);
            builder.Services.AddSingleton(typeof(IServiceInfo), serviceInfo);
            // 关闭netcore自动处理参数校验机制
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            builder.Services.AddZyWebCore(serviceInfo);
            return builder;
        }
    }
}
