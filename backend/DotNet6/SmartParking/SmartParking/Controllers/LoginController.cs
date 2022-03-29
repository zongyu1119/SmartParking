using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartParking.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartParking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//配置Cors,允许跨域
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private Authorize.IAuthorizeJWT _authorizeJWT;
        public LoginController(IConfiguration configuration, ILogger<LoginController> logger, Authorize.IAuthorizeJWT authorizeJWT)
        {
            _configuration = configuration;
            _logger = logger;
           _authorizeJWT=authorizeJWT;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public string Login([FromBody]ViewModels.UserLogin user)
        {
            _logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name} Args:{user.ToString()}");
            return _authorizeJWT.GetJWTBear(user);
        }
      
        /// <summary>
        /// pass Authorize test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="2")]
        public string Hello(string name)
        {
            string currRole = HttpContext.User.Claims.Where(x=>x.Type==ClaimTypes.Role).FirstOrDefault().ToString();
            return $"Hello {name},you pass Authorize.Role is {currRole}";
        }
    }
}
