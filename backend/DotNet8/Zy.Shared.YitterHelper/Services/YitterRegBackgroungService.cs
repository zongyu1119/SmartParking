using Nacos.V2;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Consts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Zy.Shared.Cache.Services;
using Zy.Shared.Extensions;
using Zy.Shared.DistributedLock.Services;
using Zy.Shared.Constraint;

namespace Zy.Shared.YitterHelper.Services
{
    public class YitterRegBackgroungService(
        Lazy<INacosNamingService> nacosService,
        Lazy<IConfiguration> configuration,
        Lazy<ICacheService> cacheService,
        Lazy<IDistributedLockService> distributedLock,
        Lazy<ServiceInfo> service,
        ILogger<YitterRegBackgroungService> logger,
        Lazy<IEventListener> eventListener) : BackgroundService, IDisposable
    {
        private readonly Lazy<INacosNamingService> _nacosService = nacosService;
        private readonly Lazy<IConfiguration> _configuration = configuration;
        private readonly Lazy<ICacheService> _cacheService = cacheService;
        private readonly Lazy<IDistributedLockService> _lock = distributedLock;
        private readonly string YitterWorkerIDCacheKey = CacheKeyConsts.cacheKeyPrefixShared + $":{service.Value.ShortName}:Yitter:WorkerId";
        private readonly string _serviceName = service.Value.ShortName;
        private int YitterWorkerId = 0;
        private const int MaxYitterId = 512;
        private readonly ILogger<YitterRegBackgroungService> _logger = logger;
        private readonly Lazy<IEventListener> _eventListener = eventListener;
        private Timer _timer;

        public override void Dispose()
        {
            Console.WriteLine("Dispose");
            base.Dispose();
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            var lockKey = CacheKeyConsts.cacheKeyPrefixShared + "Yitter:Lock:"+ _serviceName;
            var lockValue = await _lock.Value.DistributedLock(lockKey);
            try
            {
                var workerIds = await _cacheService.Value.GetAsync<List<int>>(YitterWorkerIDCacheKey);
                if (workerIds != null && workerIds.Any())
                {
                    if (workerIds.Contains(YitterWorkerId))
                        workerIds.Remove(YitterWorkerId);
                    if (workerIds.Any())
                        await _cacheService.Value.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromDays(30).TotalSeconds);
                    else
                        await _cacheService.Value.DeleteAsync(YitterWorkerIDCacheKey);
                    _logger.LogInformation($"Yitter ZyIdGenerator Remove:{YitterWorkerId}.");
                }
            }
            finally
            {
                await _lock.Value.DistributedUnLock(lockKey, lockValue);
                await _timer.DisposeAsync();
            }
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }
        public async override Task StartAsync(CancellationToken cancellationToken)
        {
            await _nacosService.Value.Subscribe(_serviceName, _eventListener.Value);
            await InitYitter();
            _timer = new Timer(checkWorkId, null, 600 * 1000, 600 * 1000);
        }
        private async void checkWorkId(Object stateInfo)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}Yitter Check Timer Run.");
            var workerIds = await _cacheService.Value.GetAsync<Dictionary<int, long>>(YitterWorkerIDCacheKey);
            if (workerIds != null && workerIds.TryGetValue(YitterWorkerId, out var ticks))
            {
                ticks = DateTime.Now.Ticks;
                workerIds.Remove(YitterWorkerId);
                workerIds.Add(YitterWorkerId, ticks);
            }
            if (workerIds == null)
                await InitYitter();
            else
            {
                var expiredList = workerIds.Where(x => x.Value < (DateTime.Now.Ticks - TimeSpan.FromSeconds(1200).Ticks));
                expiredList.ForEach(item =>
                {
                    workerIds.Remove((int)item.Key);
                });
                await _cacheService.Value.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromSeconds(1200).TotalSeconds);
            }
        }
        /// <summary>
        /// 初始化YitterId
        /// </summary>
        /// <returns></returns>
        private async Task InitYitter()
        {
            var lockKey = CacheKeyConsts.cacheKeyPrefixShared + "Yitter:Lock:" + _serviceName;
            var lockValue = await _lock.Value.DistributedLock(lockKey);
            try
            {
                var workerIds = await _cacheService.Value.GetAsync<Dictionary<int, long>>(YitterWorkerIDCacheKey);
                if (workerIds != null && workerIds.Count != 0)
                {
                    YitterWorkerId = workerIds.OrderByDescending(x => x.Key).FirstOrDefault().Key + 1;
                    if (YitterWorkerId >= MaxYitterId)
                    {
                        for (int i = 0; i < MaxYitterId; i++)
                        {
                            if (workerIds.Any(x => x.Value == i))
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
                await _cacheService.Value.SetAsync(YitterWorkerIDCacheKey, workerIds, (long)TimeSpan.FromSeconds(1200).TotalSeconds);
            }
            finally
            {
                await _lock.Value.DistributedUnLock(lockKey, lockValue);
            }
        }
    }

}
