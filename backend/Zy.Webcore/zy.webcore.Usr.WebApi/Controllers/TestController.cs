using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Application.Filter;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.WebApi.Controllers;

namespace zy.webcore.Usr.WebApi.Controllers
{
    [ZyAllowUnAuthorization]
    public class TestController : ZyControllerBase
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
        public AppSrvResult<object> GetConfig([FromQuery] string key)
        {
            return new AppSrvResult<string>(_configuration[key]);
        }
    }
}
