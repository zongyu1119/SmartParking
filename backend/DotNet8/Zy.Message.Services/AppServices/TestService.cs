using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Message.Constraint.IServices;
using Zy.Shared.Cap;

namespace Zy.Message.Services.AppServices
{
    public class TestService(IZyCapPublisher zyCapPublisher) : ITestService
    {
        private readonly IZyCapPublisher _publisher=zyCapPublisher;
        public async Task<string> Publish(string message)
        {
            var eventData = new TestEvent(ZyIdGenerator.NextId())
            {
                Data = message
            };
            await _publisher.PublishAsync(eventData);
            return message;
        }
    }
}
