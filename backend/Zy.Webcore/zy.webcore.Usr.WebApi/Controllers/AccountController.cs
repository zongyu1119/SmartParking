using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Application.Filter;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.WebApi.Controllers;
using zy.webcore.Usr.Constraint.Dtos.Account;
using zy.webcore.Usr.WebApi.Authorize;

namespace zy.webcore.Usr.WebApi.Controllers
{   
    public class AccountController : ZyControllerBase
    {
        private readonly IAccountService _jwtService;
        public AccountController(IAccountService jwtService)
        {
            _jwtService = jwtService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ZyAllowUnAuthorization]
        public async Task<AppSrvResult<LoginResDto>> Login(AccountLoginDto dto)
        {
            return await _jwtService.GetJWTBearAsync(dto);
        }
    }
}
