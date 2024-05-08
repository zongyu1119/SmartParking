using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Cache.Services;
using Zy.Shared.Redis.Register;

namespace Zy.Shared.Cache.Register
{
    public static class RegisterCache
    {
        /// <summary>
        /// 注册缓存
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCache(this IServiceCollection services)
        {          
            services.AddRedis();
            services.AddSingleton<ICacheService, RedisCacheService>();
            return services;
        }
    }
}
