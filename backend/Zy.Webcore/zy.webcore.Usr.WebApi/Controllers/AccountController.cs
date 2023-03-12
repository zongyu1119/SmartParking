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
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ZyAllowUnAuthorization]
        public async Task<AppSrvResult<LoginResDto>> PcLogin(AccountLoginDto dto)
        {
            return await _accountService.LoginAsync(dto,Share.Enum.Usr.ClientTypeEnum.PC);
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("captch")]
        [ZyAllowUnAuthorization]
        public async Task<AppSrvResult<CaptchOutputDto>> GetCaptchAsync()
        {
            return await _accountService.GetCaptchAsync();
        }
    }
}
