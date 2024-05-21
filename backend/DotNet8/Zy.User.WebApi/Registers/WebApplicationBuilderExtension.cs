using Zy.User.Repository.Registers;
using Zy.Shared.Constraint;
using Zy.Shared.WebApi.Register;
using Zy.User.Services.Register;

namespace Zy.User.WebApi.Registers
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
            builder.Services.AddService(serviceInfo, config);
            builder.Services.AddDbcontextServices(serviceInfo, config);
            builder.Services.AddSignalR();
            builder.Services.AddZyBackGroundService();

            return builder;
        }
       
    }
}
