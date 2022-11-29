
using Serilog;
using Service;
using SmartParking.Authorize;
using SmartParking.Common;
using SmartParking.Share.Core;
using SmartParking.Share.Entity;
using SmartParking.Share.ObjExt;
using SmartParking.Share.RedisHelper;
using System.Reflection;

namespace SmartParking.Registrar
{
    /// <summary>
    /// 
    /// </summary>
    public static class BaseRegistrarBuilderExtension
    {
        public static WebApplicationBuilder BaseRegistrarBuilder(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile(AppContext.BaseDirectory + "/appsettings.shared." + builder.Environment.EnvironmentName + ".json", optional: true, reloadOnChange: true);
            builder.Configuration.AddJsonFile(AppContext.BaseDirectory + "/appsettings." + builder.Environment.EnvironmentName + ".json", optional: true, reloadOnChange: true);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //简单的配置文件读取类
            //builder.Services.AddSingleton(new AppHelper.AppSettings(configuration));
            //redis缓存
            builder.Services.AddSingleton<IRedisManage, RedisManage>();
            /// <summary>
            /// AutoMapper依赖
            /// </summary>
            // builder.Services.AddAutoMapper(typeof(Service.Comm.AutoMapperConfig));//如果在web层可以这样
            builder.Services.AddAutoMapper(Assembly.Load("SmartParking.Server.Service"));//Service层可以这样，会自动寻找
          
            /// <summary>
            /// 注入NewtonsoftJson
            /// </summary>
            builder.Services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
            });

            //将AudienceValidator添加到DI
            //builder.Services.AddScoped<SmartParking.Common.AuditFilterAttribute>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = false;
                //options.Cookie.IsEssential = true;
            });
            builder.Services.AddScoped(typeof(DbContext),typeof(smartparkingContext));

            //注入数据库资源
            builder.Services.AddScoped(typeof(IEFRepository<Entity>),typeof(EFRepository<Entity>));

            //批量注入service
            builder.Services.registerLifetimesByAttribute(ServiceLifetime.Singleton);
            builder.Services.registerLifetimesByAttribute(ServiceLifetime.Scoped);
            builder.Services.registerLifetimesByAttribute(ServiceLifetime.Transient);

            builder.Services.AddSingleton(typeof(ServiceInterceptor));
            builder.Services.AddScoped(typeof(ServiceInterceptor));
            builder.Services.AddScoped<IMapper, Mapper>();
            
            builder.Services.AddScoped(typeof(smartparkingContext));
            //拦截器
            //过滤器
            builder.Services.AddScoped<SmartParking.Common.AuditFilterAttribute>();
            //注入JWT
            builder.Services.AddScoped<IAuthorizeJWT, AuthorizeJWT>();
            builder.Services.AddScoped(typeof(UserContext));
            // 注入Service程序集

            // 日志
            builder.Host.UseSerilog((context, logger) =>
            {
                logger.ReadFrom.Configuration(context.Configuration);
                logger.Enrich.FromLogContext();
            });
            //这个配置在调试时是不发挥作用的，实际部署后可以用
            builder.WebHost.UseUrls(new[] { builder.Configuration["Url"].ToString() });

            builder.Services.AddCors(cor =>
            {
                cor.AddPolicy("Cors", policy =>
                {
                    policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddCap(c =>
            {
                c.UseMySql(builder.Configuration["ConnectionStrings:mysql"]);
                c.UseRabbitMQ(mq => builder.Configuration.GetSection("RabbitMQ"));
            });
            return builder;
        }
        /// <summary>
        /// 批量注入依赖
        /// </summary>
        /// <param name="service"></param>
        /// <param name="serviceLifetime"></param>
        private static void registerLifetimesByAttribute(this IServiceCollection service, ServiceLifetime serviceLifetime)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => x.GetCustomAttributes(typeof(AppServiceAttribute), false).Any()
              && x.GetCustomAttribute<AppServiceAttribute>()?.Lifetime ==serviceLifetime
              &&x.IsClass&&!x.IsAbstract)
              .ToList();
            if (types.Any())
                types.ForEach(x =>
                {
                    var interfaces = x.GetInterfaces();
                    interfaces.ForEach(s =>
                    {
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Transient:
                                service.AddTransient(s, x);
                                break;
                            case ServiceLifetime.Singleton:
                                service.AddSingleton(s, x);
                                break;
                            case ServiceLifetime.Scoped:
                                service.AddScoped(s, x);
                                break;
                        }
                    });
                });
        }
    }
}
