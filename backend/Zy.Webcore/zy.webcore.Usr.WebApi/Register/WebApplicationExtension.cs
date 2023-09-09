using System.Runtime.CompilerServices;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.WebApi.Register;

namespace zy.webcore.Usr.WebApi.Register
{
    public static class WebApplicationExtension
    {
        public static WebApplication UseZyMiddleware(this WebApplication app)
        {
            var serviceInfo = app.Services.GetRequiredService<IServiceInfo>();
            var middlewareRegistarType = serviceInfo.StartAssembly.ExportedTypes.FirstOrDefault(m => m.IsAssignableTo(typeof(IMiddlewareRegistrar)) && m.IsNotAbstractClass(true));
            if (middlewareRegistarType is null)
                throw new NullReferenceException(nameof(IMiddlewareRegistrar));

            var middlewareRegistar = Activator.CreateInstance(middlewareRegistarType, app) as IMiddlewareRegistrar;
            middlewareRegistar.UseZyWebCore();
            return app;
        }
    }
}
