using System.Reflection;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Usr.Application.Register;
using zy.webcore.Share.WebApi.Register;
using zy.webcore.Share.Extensions;

namespace zy.webcore.Usr.WebApi.Register
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder ConfigureService(this WebApplicationBuilder builder,IServiceInfo serviceInfo)
        {
            // Add services to the container.
            if (builder.Environment.IsDevelopment())//仅开发环境加载本地配置，其他环境走Consul配置中心 Modify by garfield 20221019
            {
                builder.Configuration.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.shared.{builder.Environment.EnvironmentName}.json", true, true);
            }

            builder.Configuration.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.{builder.Environment.EnvironmentName}.json", true, true);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => c.IncludeXmlComments("/Swagger/doc.xml", true));

            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            //ServiceCollection
            builder.Services.AddSingleton(builder);
            builder.Services.ReplaceConfiguration(builder.Configuration);
            builder.Services.AddZyWebCoreDefault();
            builder.Services.AddSingleton(typeof(IServiceInfo), serviceInfo);
            builder.Services.AddZyWebCore(serviceInfo);
            return builder;
        }

      
    }
}
