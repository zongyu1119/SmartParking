using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartParking.Controllers.Test
{
    /// <summary>
    /// CAP测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CapTestController : ControllerBase
    {
        /// <summary>
        /// CAP发送测试
        /// </summary>
        /// <param name="capPublish"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Get([FromServices] ICapPublisher capPublish)
        {
            await capPublish.PublishAsync<string>("Test Cap", "hello，Cap!");  //发布Order.Created事件
            return "Cap Seng OK!";
        }
        [NonAction]
        [CapSubscribe("Order.Created")]    //监听Order.Created事件
        public async Task CapTestEventHand(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
