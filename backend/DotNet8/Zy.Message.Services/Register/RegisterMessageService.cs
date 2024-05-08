using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Zy.Shared.Service.Register;
using Zy.Shared.Cap.Register;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Zy.Message.Services.Register
{
    /// <summary>
    /// 注册消息服务
    /// </summary>
    public static class RegisterMessageService
    {
        /// <summary>
        /// 注册Service服务
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageService(this IServiceCollection service,ServiceInfo serviceInfo,IConfiguration config)
        {
            var serviceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var constraintAssembly = Assembly.Load(serviceAssembly.GetName().Name.Replace("Services", "Constraint"));
            service.AddZyServices(serviceAssembly, constraintAssembly);

            service.AddCapEventBus(config, serviceInfo, serviceAssembly);
            return service;
        }
    }
}
