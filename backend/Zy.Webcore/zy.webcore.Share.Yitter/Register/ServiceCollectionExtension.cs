using Microsoft.Extensions.DependencyInjection;
using zy.webcore.Share.Yitter.Services;

namespace zy.webcore.Share.Yitter.Register
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
            return service;
        }
    }
}
