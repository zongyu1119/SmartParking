using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.WebApi.Controllers;
using zy.webcore.Usr.Constraint.Dtos.Account;
using zy.webcore.Usr.WebApi.Authorize;

namespace zy.webcore.Usr.WebApi.Controllers
{
    public class AccountController : ZyControllerBase
    {
        private readonly IAuthorizeJWT _jwtService;
        public AccountController(IAuthorizeJWT jwtService)
        {
            _jwtService = jwtService;
        }
        public async Task<AppSrvResult<(string token,UserDetailInfoDto userInfo)>> Login(AccountLoginDto dto)
        {
            var res= await _jwtService.GetJWTBearAsync(dto);
        }
    }
}
