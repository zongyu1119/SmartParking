using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Cache.Services;

namespace zy.webcore.Share.Cache.Register
{
    /// <summary>
    /// 注册缓存
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册缓存
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddCacheService(this IServiceCollection service)
        {
            service.AddSingleton(typeof(ICacheService),typeof(CacheService));
            return service;
        }
    }
}
