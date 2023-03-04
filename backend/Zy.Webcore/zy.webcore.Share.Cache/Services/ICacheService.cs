using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Cache.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="cacheKey">Cache key.</param>
        /// <param name="cacheValue">Cache value.</param>
        /// <param name="expiration">Expiration FromSeconds.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task SetAsync<T>(string cacheKey, T cacheValue, long expiration=10);

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string cacheKey);
    }
}
