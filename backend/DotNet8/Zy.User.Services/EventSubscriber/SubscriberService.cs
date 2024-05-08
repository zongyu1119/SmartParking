namespace Zy.User.Services.EventSubscriber
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
