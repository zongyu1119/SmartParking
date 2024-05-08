using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Redis;
using Zy.Shared.Redis.CacheServices;

namespace Zy.Shared.Cache.Services
{

    public class RedisCacheService : ICacheService
    {
        private readonly IRedisService _redisService;
        public RedisCacheService(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteAsync(string cacheKey)
        {
            await _redisService.RemoveAsync(cacheKey);
        }

        public async Task<T> GetAsync<T>(string cacheKey)
        {
            var cache = await _redisService.GetAsync<T>(cacheKey);
            return cache;
        }

        public async Task<string> GetAsync(string cacheKey)
        {
            var cache = await _redisService.GetAsync<string>(cacheKey);
            return cache;
        }

        public async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> dataRetriever, TimeSpan expiration)
        {
            var cache = await _redisService.GetAsync<T>(cacheKey, dataRetriever, expiration);
            return cache;
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
            await _redisService.SetAsync(cacheKey, cacheValue, TimeSpan.FromSeconds(expiration));
        }

        public async Task SetAsync(string cacheKey, string cacheValue, long expiration = 10)
        {
            await _redisService.SetAsync<string>(cacheKey, cacheValue, TimeSpan.FromSeconds(expiration));
        }
    }
}
