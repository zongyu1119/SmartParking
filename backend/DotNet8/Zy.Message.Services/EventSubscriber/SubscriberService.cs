using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Cap.Events;

namespace Zy.Message.Services.EventSubscriber
{
    public class SubscriberService:ICapSubscribe
    {
        [CapSubscribe(nameof(TestEvent))]
        public void TestReceivedMessage(TestEvent t)
        {
            Console.WriteLine("Service:" + t.Data);
        }
    }
}
