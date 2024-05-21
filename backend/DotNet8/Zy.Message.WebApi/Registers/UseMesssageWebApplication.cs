using Nacos.V2.Naming.Dtos;
using Zy.Message.WebApi.ChatHubs;
using Zy.Message.Repository.Registers;
using Zy.Shared.Constraint;
using Zy.Shared.Cache.Register;
using Zy.Message.WebApi.Registers;
using Zy.Shared.WebApi.Register;
using ServiceInfo = Zy.Shared.Constraint.ServiceInfo;

namespace Zy.Message.WebApi.Registers
{
    public static class UseMesssageWebApplication
    {
        public static WebApplication UseZyApp(this WebApplication application,ServiceInfo serviceInfo)
        {
         
            application.UseZySwagger(serviceInfo)
            .UseZyWebBase()
            .UseZyHealthCheck(serviceInfo)
             .UseZyChatHub()
            .UseZyAuth()
            .UseZyRequestLog()
            .UseZyService(serviceInfo)
            .UseZyCors(serviceInfo);
            return application;
        }
        public static WebApplication UseZyChatHub(this WebApplication app)
        {
            app.MapHub<ChatHub>("/message/chatHub");
            return app;
        }
    }
}
