using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace zy.webcore.GetWay.Controllers
{
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 获得缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("GetConfig")]
        public string GetConfig([FromQuery] string key)
        {
            return _configuration[key];
        }
    }
}
