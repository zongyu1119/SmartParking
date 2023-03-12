using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Redis.CacheProvider;

namespace zy.webcore.Share.Cache.Services
{
    public class CacheService: ICacheService
    {
        private readonly ICacheProvider _cacheProvider;
        public CacheService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public async Task DeleteAsync(string cacheKey)
        {
           await _cacheProvider.RemoveAsync(cacheKey);
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var cache = await _cacheProvider.GetAsync<T>(cacheKey);
            return cache.HasValue&&!cache.IsNull?cache.Value:default(T);
        }

        public async Task<string> GetAsync(string cacheKey)
        {
            var cache = await _cacheProvider.GetAsync<string>(cacheKey);
            return cache.HasValue && !cache.IsNull ? cache.Value : null;
        }

        /// <summary>
        /// Sets the specified cacheKey, cacheValue and expiration async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="cacheKey">Cache key.</param>
        /// <param name="cacheValue">Cache value.</param>
        /// <param name="expiration">Expiration.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task SetAsync<T>(string cacheKey, T cacheValue, long expiration = 10)
        {
            await _cacheProvider.SetAsync(cacheKey,cacheValue,TimeSpan.FromSeconds(expiration));
        }

        public async Task SetAsync(string cacheKey, string cacheValue, long expiration = 10)
        {
            await _cacheProvider.SetAsync<string>(cacheKey, cacheValue, TimeSpan.FromSeconds(expiration));
        }
    }
}
