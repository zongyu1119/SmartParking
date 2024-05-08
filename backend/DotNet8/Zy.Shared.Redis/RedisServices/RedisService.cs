using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Zy.Shared.Redis.CacheServices;
using Zy.Shared.Redis.Options;
using Zy.Shared.Redis.Providers;

namespace Zy.Shared.Redis.RedisServices
{
    public class RedisService:IRedisService
    {
        private readonly RedisDatabaseProvider _dbProvider;
        /// <summary>
        /// The cache.
        /// </summary>
        private readonly IDatabase _redisDb;

        /// <summary>
        /// The servers.
        /// </summary>
        private readonly IEnumerable<IServer> _servers;
        /// <summary>
        /// 序列化和反序列化
        /// </summary>
        private readonly ProtoBufSerializer _serializer;
        private ILogger<RedisService> _logger;
        public RedisService(RedisDatabaseProvider databaseProvider,
            ILogger<RedisService> logger,
            ProtoBufSerializer protoBufSerializer) {
            _dbProvider = databaseProvider;
            _logger = logger;
            _serializer = protoBufSerializer;
            _redisDb = _dbProvider.GetDatabase();
            _servers = _dbProvider.GetServerList();
        }
        public string StringGet(string key)
        {
            return _redisDb.StringGet(key);
        }

        public void StringSet(string key, string value,TimeSpan expiration)
        {
           
                var addSec = new Random().Next(1, 3000);
                expiration = expiration.Add(TimeSpan.FromMicroseconds(addSec));//防止缓存击穿

            _redisDb.StringSet(
                key,
                value,
                expiration);
        }

        public void Remove(string key)
        {
            _redisDb.KeyDelete(key);
        }
        public T Get<T>(string key) where T : class
        {
            var result = _redisDb.StringGet(key);
            if (!result.IsNull)
            {
                var value = _serializer.Deserialize<T>(result);
                return value;
            }
            else
            {
                return null;
            }
        }
       public void Set<T>(string key,T value, TimeSpan expiration)
        {
            {
                var addSec = new Random().Next(1,3000);
                expiration = expiration.Add(TimeSpan.FromMicroseconds(addSec));
            }

            _redisDb.StringSet(
                key,
                _serializer.Serialize(value),
                expiration);
        }

        public async Task<string> StringGetAsync(string key)
        {
            return await _redisDb.StringGetAsync(key);
        }

        public async Task StringSetAsync(string key, string value, TimeSpan expiration)
        {
            var addSec = new Random().Next(1, 3000);
            expiration = expiration.Add(TimeSpan.FromMicroseconds(addSec));//防止缓存击穿

           await  _redisDb.StringSetAsync(
                key,
                value,
                expiration);
        }

        public async Task RemoveAsync(string key)
        {
            await _redisDb.KeyDeleteAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var result = await _redisDb.StringGetAsync(key);
            if (!result.IsNull)
            {
                var value = _serializer.Deserialize<T>(result);
                return value;
            }
            else
            {
                return default(T);
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            {
                var addSec = new Random().Next(1, 3000);
                expiration = expiration.Add(TimeSpan.FromMicroseconds(addSec));
            }

            await  _redisDb.StringSetAsync(
                key,
                _serializer.Serialize(value),
                expiration);
        }

        public async Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> dataRetriever, TimeSpan expiration)
        {
            var result = await _redisDb.StringGetAsync(cacheKey);
            if (!result.IsNull)
            {
                var value = _serializer.Deserialize<T>(result);
                return value;
            }
            else
            {
                var data=await dataRetriever();
                await this.SetAsync<T>(cacheKey,data,expiration);
                return data;
            }
        }

        /// <summary>
        /// 分布式锁
        /// </summary>
        /// <param name="lockName"></param>
        /// <param name="expiry"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async  Task<string> LockAsync(string lockName, int expiry = 10)
        {
            var lockToken = Guid.NewGuid().ToString("N");
            if (await _redisDb.LockTakeAsync(lockName, lockToken, TimeSpan.FromSeconds(expiry)))
                return lockToken;
            else
                throw new InvalidOperationException($"获取分布式锁失败:{lockName}");
        }
        /// <summary>
        /// 分布式锁解锁
        /// </summary>
        /// <param name="lockName">锁名称</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async  Task<bool> UnLockAsync(string lockName, string lockToken)
        {
            return await _redisDb.LockReleaseAsync(lockName, lockToken);
        }
    }
}
