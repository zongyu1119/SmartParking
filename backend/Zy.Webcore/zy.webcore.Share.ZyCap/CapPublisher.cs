using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.ZyCap
{
    public class CapPublisher
    {
        private ICapPublisher _publisher;
        public CapPublisher(ICapPublisher publisher)
        {
            _publisher = publisher;
        }
        public void Publish<T>(T obj) where T : class
        {
            _publisher.Publish(typeof(T).Name, obj);
        }
    }
}
