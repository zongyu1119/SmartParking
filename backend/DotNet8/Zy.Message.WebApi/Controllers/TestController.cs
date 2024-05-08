using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nacos.V2;
using Zy.Message.Constraint.IServices;
using Zy.Shared.Cache.Services;

namespace Zy.Message.WebApi.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <param name="cache"></param>
    /// <param name="configuration"></param>
    [Route("msg/[Controller]/[Action]")]
    [ApiController]
    [AllowAnonymous]
    public class TestController(ICacheService cache, IConfiguration configuration,ITestService service) : ControllerBase
    {
        private readonly ICacheService _cache = cache;
        private readonly IConfiguration _configuration = configuration;
        private readonly ITestService _testService=service;
        [HttpGet]
        public async Task<ActionResult> SetCache(string key,string value)
        {
             await _cache.SetAsync(key, value);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<string>> GetCache(string key)
        {
            return await _cache.GetAsync(key);
        }
        [HttpGet]
        public  ActionResult<string?> GetConfig(string key)
        {
            var config = _configuration[key];
            return config;
        }
        [HttpPost]
        public async Task<ActionResult<string>> PublishAsync(string message)
        {
            return await _testService.Publish(message);
        }
    }
}
