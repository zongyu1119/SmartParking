using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Zy.Shared.Service.Register;
using Zy.Shared.Cap.Register;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Zy.User.Services.Register
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public static class RegisterService
    {
        /// <summary>
        /// 注册Service服务
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddService(this IServiceCollection service,ServiceInfo serviceInfo,IConfiguration config)
        {
            var serviceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var constraintAssembly = Assembly.Load(serviceAssembly.GetName().Name.Replace("Services", "Constraint"));
            service.AddZyServices(serviceAssembly, constraintAssembly);

            service.AddCapEventBus(config, serviceInfo, serviceAssembly);
            return service;
        }
    }
}
