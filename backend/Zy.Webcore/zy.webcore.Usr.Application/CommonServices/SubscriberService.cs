using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Application.CommonServices
{
    /// <summary>
    /// Cap消息接收
    /// </summary>
    public class  SubscriberService:ICapSubscribe
    {
        [CapSubscribe("zy.test")]
        public void TestReceivedMessage(string msg)
        {
            Console.WriteLine("Service:" + msg);
        }
    }
}
