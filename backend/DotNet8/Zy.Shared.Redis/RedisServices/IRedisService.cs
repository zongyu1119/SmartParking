using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Redis.CacheServices
{
    /// <summary>
    /// Redis服务
    /// </summary>
    public interface IRedisService
    {
        /// <summary>
        /// 获得String类型的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string StringGet(string key);
        Task<string> StringGetAsync(string key);
        /// <summary>
        /// 设置String类型的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        void StringSet(string key, string value, TimeSpan expiration);
        Task StringSetAsync(string key, string value, TimeSpan expiration);
        /// <summary>
        /// 移除值
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveAsync(string key);
        /// <summary>
        /// 获得缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 获得缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        void Set<T>(string key, T value, TimeSpan expiration);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        Task SetAsync<T>(string key,T value, TimeSpan expiration) ;
        /// <summary>
        /// 获取缓存，如无，则先设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="dataRetriever"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> dataRetriever, TimeSpan expiration);

        /// <summary>
        /// 分布式锁
        /// </summary>
        /// <param name="lockName">锁名称</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        Task<string> LockAsync(string lockName, int expiry = 10);
        /// <summary>
        /// 分布式锁解锁
        /// </summary>
        /// <param name="lockName"></param>
        /// <returns></returns>
        Task<bool> UnLockAsync(string lockName, string lockToken);
    }
}
