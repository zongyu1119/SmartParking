﻿using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Application.Filter;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.WebApi.Controllers;

namespace zy.webcore.Usr.WebApi.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    [ZyAllowUnAuthorization]
    [Route("usr/[controller]")]
    public class TestController : ZyControllerBase
    {
        private IConfiguration _configuration;
        private ICapPublisher _publisher;
        public TestController(IConfiguration configuration,ICapPublisher publisher)
        {
            _configuration = configuration;
            _publisher = publisher;
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
        /// <summary>
        /// 消息发布测试
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpGet("Publish")]
        public AppSrvResult<bool> Publish([FromQuery]string msg)
        {
            _publisher.Publish("zy.test", msg);
            return new AppSrvResult<bool>(true);
        }
    }
}
