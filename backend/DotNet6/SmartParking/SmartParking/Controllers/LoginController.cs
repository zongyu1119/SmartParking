
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Common;
using Service.Comm;
using Service.Models;
using Service.IService;
using RedisHelper;

namespace SmartParking.Controllers
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("Cors")]//配置Cors,允许跨域
    public class LoginController : ZyControllerBase
    {
        private readonly Authorize.IAuthorizeJWT authorizeJWT;//认证
        private readonly IUserInfoService service;
        private readonly IRedisManage redis;
        /// <summary>
        /// 登录相关
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_authorizeJWT"></param>
        /// <param name="_service"></param>
        public LoginController(IConfiguration _configuration, 
            ILogger<LoginController> _logger, 
            Authorize.IAuthorizeJWT _authorizeJWT, 
            IUserInfoService _service,
            IRedisManage _redis) :base(_configuration,_logger)
        {
            authorizeJWT= _authorizeJWT;
            service= _service;
            redis= _redis;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public HttpResponseMessage Login([FromBody]ViewModels.UserLoginArgs user)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{user.ToString()}");
             HttpResponseMessage res = new HttpResponseMessage();
            if(authorizeJWT.GetJWTBear(user,out string bear))
            {
                redis.Set($"Bear{user.UserName}",bear,TimeSpan.FromHours(24));
                res.StatusCode = System.Net.HttpStatusCode.OK;
                res.Headers.Add("Authorization", bear);
            }
            else
            {
                res.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                res.Content=new StringContent(bear);
            }
            return res;
        }
        /// <summary>
        /// 获得用户的登录信息，只要有工作台权限的人就可以获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.Workbench}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public Res<UserDetailInfoModel> GetUserDetailInfoToView()
        {
            logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name} ");
            return service.GetUserDetailInfoToView((int)base.UserId);
        }
        /// <summary>
        /// pass Authorize test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.Workbench}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public string Hello(string name)
        {
            return $"Hello {name},you pass Authorize.UserID is {base.UserId};bear:{redis.Get(name)}";
        }
    }
    
}
