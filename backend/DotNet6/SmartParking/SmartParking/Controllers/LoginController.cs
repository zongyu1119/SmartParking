
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmartParking.Common;
using Service.Comm;
using Service.Models;
using Service.IService;

namespace SmartParking.Controllers
{
    /// <summary>
    /// 登录相关
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//配置Cors,允许跨域
    public class LoginController : ZyControllerBase
    {

        private readonly Authorize.IAuthorizeJWT authorizeJWT;//认证
        private readonly IUserInfoService service;
        //依赖注入
        public LoginController(IConfiguration _configuration, ILogger<LoginController> _logger, Authorize.IAuthorizeJWT _authorizeJWT, IUserInfoService _service) :base(_configuration,_logger)
        {
            authorizeJWT= _authorizeJWT;
            service= _service;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Login([FromBody]ViewModels.UserLoginArgs user)
        {
            logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{user.ToString()}");
             HttpResponseMessage res = new HttpResponseMessage();
            if(authorizeJWT.GetJWTBear(user,out string bear))
            {

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
        public Res<UserDetailInfoModel> GetUserDetailInfoToView(int id)
        {
            logger.LogError($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{id}");
            return service.GetUserDetailInfoToView(id);
        }
        /// <summary>
        /// pass Authorize test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = $"{PowerType.Select}:{PowerID.Workbench}")]
        public string Hello(string name)
        {
            return $"Hello {name},you pass Authorize.UserID is {base.UserId}";
        }
    }
    
}
