using Microsoft.Extensions.DependencyInjection;
using Zy.Shared.Redis.CacheServices;
using Zy.Shared.Redis.Options;
using Zy.Shared.Redis.Providers;
using Zy.Shared.Redis.RedisServices;

namespace Zy.Shared.Redis.Register
{
    public static class RegisterRedis
    {
        /// <summary>
        /// 注册Redis
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedis(this IServiceCollection services)
        {
            services.AddSingleton<ProtoBufSerializer>();
            services.AddSingleton(typeof(RedisDatabaseProvider));
            services.AddSingleton<IRedisService, RedisService>();
            return services;
        }
    }
}
