namespace Zy.User.Services.AppServices
{
    public class TestService(IZyCapPublisher zyCapPublisher) :AbstractService,ITestService
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
