using Nacos.V2;
using Nacos.V2.Naming.Event;

namespace zy.webcore.Share.Application.Nacos
{
    public class NacosListener : IEventListener
    {
        private readonly Lazy<INacosNamingService> _nacosService;
        private readonly Lazy<IConfiguration> _configuration;
        public NacosListener(Lazy<INacosNamingService> nacosService,
            Lazy<IConfiguration> configuration)
        {
            _configuration= configuration;
            _nacosService= nacosService;
        }

        public async Task OnEvent(IEvent @event)
        {
            var info = @event as InstancesChangeEvent;
            var instances = await _nacosService.Value.GetAllInstances(info.ServiceName);
        }
    }
}
