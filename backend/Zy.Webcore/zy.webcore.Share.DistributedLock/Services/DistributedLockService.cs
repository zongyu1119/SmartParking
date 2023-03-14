using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Cache.Services;

namespace zy.webcore.Share.DistributedLock.Services
{
    public class DistributedLockService : IDistributedLockService
    {
        private readonly ICacheService _cacheService;
        public DistributedLockService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<long> DistributedLock(string key, bool autoRenewal = false)
        {
            
        }

        public async Task DistributedUnLock(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
