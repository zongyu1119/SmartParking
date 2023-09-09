using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.ZyCap.Events;

namespace zy.webcore.Usr.Application.CommonServices
{
    /// <summary>
    /// Cap消息接收
    /// </summary>
    public class  SubscriberService:ICapSubscribe
    {
        [CapSubscribe(nameof(TestEvent))]
        public void TestReceivedMessage(TestEvent t)
        {
            Console.WriteLine("Service:" + t.Name);
        }
    }
}
