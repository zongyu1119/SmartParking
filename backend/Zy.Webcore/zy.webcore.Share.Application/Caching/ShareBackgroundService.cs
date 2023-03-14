using Microsoft.Extensions.Hosting;
using Nacos.AspNetCore.V2;
using Nacos.Microsoft.Extensions.Configuration;
using Nacos.V2;

namespace zy.webcore.Share.Application.Caching
{
    public class ShareBackgroundService : BackgroundService
    {
        private readonly  Lazy<Nacos.V2.INacosNamingService> _nacosService;
        private readonly Lazy<IConfiguration> _configuration;
        private readonly ICacheService _cacheService;
        public ShareBackgroundService(
            Lazy<Nacos.V2.INacosNamingService> nacosService,
            Lazy<IConfiguration> configuration)
        {
            _nacosService = nacosService;
            _configuration = configuration;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await InitYitter();
        }
        /// <summary>
        /// 使用服务中心注册的nacos数量来确定yitter的workid
        /// </summary>
        /// <returns></returns>
        private async Task InitYitter()
        {
            var nacosConfig = _configuration.Value.GetSection("NacosConfig").Get<NacosAspNetOptions>();
            var instances = await _nacosService.Value.SelectInstances(nacosConfig.ServiceName,nacosConfig.GroupName,true);
            ZyIdGenerator.SetIdGenerator((ushort)instances.Count);
        }
    }
}
