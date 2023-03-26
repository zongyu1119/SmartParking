using Microsoft.Extensions.Hosting;
using Nacos.AspNetCore.V2;
using Nacos.Microsoft.Extensions.Configuration;
using Nacos.V2;
using Nacos.V2.Naming.Dtos;
using System.Linq;
using System.Threading;
using zy.webcore.Share.Application.Nacos;
using zy.webcore.Share.Consts;
using zy.webcore.Share.DistributedLock.Services;
using zy.webcore.Share.Yitter.Services;

namespace zy.webcore.Share.Application.Service
{
    public class ShareBackgroundService : BackgroundService,IDisposable
    {
        private readonly Lazy<INacosNamingService> _nacosService;
        private readonly Lazy<IConfiguration> _configuration;
        private readonly ICacheService _cacheService;
        private readonly IDistributedLockService _lock;
        private readonly string YitterWorkerIDCacheKey;
        private int YitterWorkerId = 0;
        private const int MaxYitterId = 512;
        private readonly ILogger<ShareBackgroundService> _logger;
        private readonly IEventListener _eventListener;
        private readonly IServiceInfo _serviceInfo;
        private Timer _timer;
        public ShareBackgroundService(
            Lazy<INacosNamingService> nacosService,
            Lazy<IConfiguration> configuration,
            ICacheService cacheService,
            IDistributedLockService distributedLock,
            IServiceInfo service,
            ILogger<ShareBackgroundService> logger,
            IEventListener eventListener)
        {
            _nacosService = nacosService;
            _configuration = configuration;
            _cacheService = cacheService;
            _lock = distributedLock;
            YitterWorkerIDCacheKey = CacheKeyPrefix.cacheKeyPrefixShare + $"{service.ShortName}:Yitter:WorkerId";
            _logger = logger;
            _eventListener = eventListener;
            _serviceInfo = service;
        }
        public override void Dispose()
        {
            Console.WriteLine("Dispose");
            base.Dispose();
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            var lockKey = CacheKeyPrefix.cacheKeyPrefixShare + "Yitter:Lock";
            var lockValue = await _lock.DistributedLock(lockKey);
            try
            {
                var workerIds = await _cacheService.GetAsync<List<int>>(YitterWorkerIDCacheKey);
                if (workerIds != null && workerIds.Any())
                {
                    if (workerIds.Contains(YitterWorkerId))
                        workerIds.Remove(YitterWorkerId);
                    if (workerIds.Any())
                        await _cacheService.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromDays(30).TotalSeconds);
                    else
                        await _cacheService.DeleteAsync(YitterWorkerIDCacheKey);
                    _logger.LogInformation($"Yitter ZyIdGenerator Remove:{YitterWorkerId}.");
                }
            }
            finally
            {
                await _lock.DistributedUnLock(lockKey, lockValue);
                await _timer.DisposeAsync();
            }
          }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
        }
        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await _nacosService.Value.Subscribe("usr", _eventListener);
            await InitYitter();
            _timer = new Timer(checkWorkId, null, 60*1000, 60*1000);
        }
        private async void checkWorkId(Object stateInfo)
        {
            Console.WriteLine($"Yitter Check Timer Run.");
            var workerIds = await _cacheService.GetAsync<Dictionary<int, long>>(YitterWorkerIDCacheKey);
            if(workerIds.TryGetValue(YitterWorkerId, out var ticks))
            {
                ticks = DateTime.Now.Ticks;
                workerIds.Remove(YitterWorkerId);
                workerIds.Add(YitterWorkerId, ticks);
            }
            var expiredList = workerIds.Where(x => x.Value < (DateTime.Now.Ticks - TimeSpan.FromSeconds(120).Ticks));
            expiredList.ForEach(item =>
            {
                workerIds.Remove((int)item.Key);
            });
            await _cacheService.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromSeconds(120).TotalSeconds);
        }
        /// <summary>
        /// 初始化YitterId
        /// </summary>
        /// <returns></returns>
        private async Task InitYitter()
        {
            var lockKey = CacheKeyPrefix.cacheKeyPrefixShare + "Yitter:Lock";
            var lockValue = await _lock.DistributedLock(lockKey);
            try
            {
                var workerIds = await _cacheService.GetAsync<Dictionary<int,long>>(YitterWorkerIDCacheKey);
                if (workerIds != null && workerIds.Any())
                {
                    YitterWorkerId = workerIds.OrderByDescending(x => x.Key).FirstOrDefault().Key + 1;
                    if (YitterWorkerId >= MaxYitterId)
                    {
                        for (int i = 0; i < MaxYitterId; i++)
                        {
                            if (workerIds.Any(x=>x.Value==i))
                            { YitterWorkerId = i; break; }
                        }
                    }
                }
                else
                {
                    workerIds = new Dictionary<int, long>();                   
                }
                workerIds.Add(YitterWorkerId, DateTime.Now.Ticks);
                ZyIdGenerator.SetIdGenerator((ushort)YitterWorkerId);
                _logger.LogInformation($"Yitter ZyIdGenerator:{YitterWorkerId}.");
                await _cacheService.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromSeconds(120).TotalSeconds);
            }
            finally
            {
                await _lock.DistributedUnLock(lockKey, lockValue);
            }
        }
    }

   
}
