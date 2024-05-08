using Microsoft.Extensions.Configuration;
using Nacos.V2.Naming.Event;
using Nacos.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Nacos
{
    public class NacosListener(Lazy<INacosNamingService> nacosService,
        Lazy<IConfiguration> configuration) : IEventListener
    {
        public async Task OnEvent(IEvent @event)
         {
            var info = @event as InstancesChangeEvent;
            var instances = await nacosService.Value.GetAllInstances(info.ServiceName);
        }
    }
}
