using Zy.Message.Repository.Registers;
using Zy.Shared.Service.Register;
using Zy.Shared.Constraint;
using Zy.Shared.Cache.Register;
using Zy.Message.WebApi.Registers;
using Zy.Message.WebApi.ChatHubs;
using Zy.Message.Constraint.Dtos;
using Zy.Shared.WebApi.Register;
using Microsoft.OpenApi.Models;
using Zy.Message.Services.Register;

namespace Zy.Message.WebApi.Registers
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder ZyBuild(this WebApplicationBuilder builder, ServiceInfo serviceInfo)
        {
            var config = builder.Configuration;
            builder.Configuration.AddJsonFile($"appsettings.json");
            builder.Configuration.AddJsonFile($"{AppContext.BaseDirectory}/appsettings.{builder.Environment.EnvironmentName}.json", true, true);

            builder.BuildZyShared(serviceInfo);
            // Add services to the container.
            builder.Services.AddMessageService(serviceInfo, config);
            builder.Services.AddMessageDbcontextServices(serviceInfo, config);
            builder.Services.AddSignalR();
            builder.Services.AddZyBackGroundService();
            return builder;
        }
       
    }
}
