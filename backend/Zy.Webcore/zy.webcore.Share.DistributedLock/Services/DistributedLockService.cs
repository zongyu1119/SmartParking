namespace zy.webcore.Share.DistributedLock.Services
{
    public class DistributedLockService : IDistributedLockService
    {
        private readonly ICacheProvider _cacheProvider;
        public DistributedLockService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        public async Task<string> DistributedLock(string key, int expiry = 10)
        {
            return await _cacheProvider.LockAsync(key, expiry);
        }

        public async Task DistributedUnLock(string key, string value)
        {
            await _cacheProvider.UnLockAsync(key, value);
        }
    }
}
