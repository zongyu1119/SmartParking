
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Common;
using SmartParking.Server.Const.Dtos.DtoBase;
using SmartParking.Server.Const.Dtos.User;
using SmartParking.Share.RedisHelper;

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
        public async Task<HttpResponseMessage> Login([FromBody]ViewModels.UserLoginArgs user)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{user.ToString()}");
             HttpResponseMessage res = new HttpResponseMessage();
            var bear = await authorizeJWT.GetJWTBear(user);
            if (bear.Success)
            {
                base.UserId = bear.Data.user.Id;
                base.UserName = bear.Data.user.UserName;
                base.TenantId = bear.Data.user.TenantId;
                redis.Set($"Bear:{UserId}",bear,TimeSpan.FromHours(24));
                res.StatusCode = System.Net.HttpStatusCode.OK;
                res.Headers.Add("Authorization", bear.Data.bear);               
                res.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(bear.Data.user));
            }
            else
            {
                res.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                res.Content=new StringContent(bear.Message);
            }
            return res;
        }
        /// <summary>
        /// 获得用户的登录信息，只要有工作台权限的人就可以获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.Workbench}")]
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public async Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoToView()
        {
            logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name} ");
            if(base.UserId == null)
            {
                throw new Exception("登录用户获取失败！");
            }
            return await service.GetUserDetailInfoToViewAsync((long)base.UserId);
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
            return $"Hello {name},you pass Authorize.UserID is {base.UserId};bear:{redis.Get("Bear:"+UserId)}";
        }
    }
    
}
