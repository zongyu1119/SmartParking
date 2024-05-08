using Zy.Shared.Redis.CacheServices;

namespace Zy.Shared.DistributedLock.Services
{
    public class DistributedLockService(IRedisService redisService) : IDistributedLockService
    {
        public async Task<string> DistributedLock(string key, int expiry = 10)
        {
            return await redisService.LockAsync(key, expiry);
        }

        public async Task DistributedUnLock(string key, string value)
        {
            await redisService.UnLockAsync(key, value);
        }
    }
}
