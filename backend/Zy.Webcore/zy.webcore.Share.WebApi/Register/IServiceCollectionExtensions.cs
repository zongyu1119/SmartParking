using Microsoft.Extensions.DependencyInjection;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Share.Extensions;

namespace zy.webcore.Share.WebApi.Register
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// 通用的注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceInfo"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static IServiceCollection AddZyWebCore(this IServiceCollection services, IServiceInfo serviceInfo)
        {
            var webApiRegistarType = serviceInfo.StartAssembly.ExportedTypes.FirstOrDefault(m => m.IsAssignableTo(typeof(IDependencyRegistrar)) && m.IsNotAbstractClass(true));
            if (webApiRegistarType is null)
                throw new NullReferenceException(nameof(IDependencyRegistrar));

            var webapiRegistar = Activator.CreateInstance(webApiRegistarType, services) as IDependencyRegistrar;
            webapiRegistar.AddZyWebCore();

            return services;
        }
    }
}
