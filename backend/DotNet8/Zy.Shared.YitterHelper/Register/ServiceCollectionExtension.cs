using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.YitterHelper.Services;

namespace Zy.Shared.YitterHelper.Register
{
    /// <summary>
    /// 注册Yitter
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册Yitter
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddYitter(this IServiceCollection service)
        {
            service.AddSingleton(typeof(ZyIdGenerator));
            service.AddHostedService<YitterRegBackgroungService>();
            return service;
        }
    }
}
