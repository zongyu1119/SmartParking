using Zy.Shared.WebApi.Register;
using ServiceInfo = Zy.Shared.Constraint.ServiceInfo;

namespace Zy.User.WebApi.Registers
{
    public static class UseWebApplication
    {
        public static WebApplication UseZyApp(this WebApplication application, ServiceInfo serviceInfo)
        {
            application.UseZySwagger(serviceInfo)
                        .UseZyWebBase()
                        .UseZyHealthCheck(serviceInfo)
                        .UseZyAuth()
                        .UseZyRequestLog()
                        .UseZyService(serviceInfo)
                        .UseZyCors(serviceInfo);
            return application;
        }
    }
}