
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using zy.webcore.Share.Application.Service;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Encode;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Options;

namespace zy.webcore.Usr.Application.Services
{
    /// <summary>
    /// JWT认证
    /// </summary>
    public class AccountService : AbstractAppService, IAccountService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AccountService> logger;
        private readonly IUserService service;
        /// <summary>
        /// JWT认证
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public AccountService(IConfiguration _configuration, ILogger<AccountService> _logger, IUserService _service)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.service = _service;
        }
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<AppSrvResult<LoginResDto>> GetJWTBearAsync(AccountLoginDto user)
        {
            var jwtConfig = configuration.GetSection("JWT").Get<JwtOption>();
            var userDetailInfoModel =await service.GetUserDetailInfoAsync(user.UserAccount);
            if(userDetailInfoModel == null)
            {
                logger.LogError("登录用户不存在！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "登录用户不存在！");
            }
            var psd = RSAEncode.RSADecrypt(userDetailInfoModel.Password);
            if (user.Password != psd)
            {
                logger.LogError("用户名或密码错误！");
                return Problem<LoginResDto>(HttpStatusCode.BadRequest, "用户名或密码错误！");
            }
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>()
            {
                new Claim("Id", userDetailInfoModel.UserId.ToString()),
                new Claim(ClaimTypes.Name, userDetailInfoModel.UserName),
                new Claim("Account", userDetailInfoModel.Account)
            };
            if (userDetailInfoModel.RoleIds != null && userDetailInfoModel.RoleIds.Any())
                userDetailInfoModel.RoleIds.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.ToString())));
            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;
            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            // 5. 从 appsettings.json 中读取Expires
            var expires = Convert.ToDouble(jwtConfig.Expires);           
            // 6. 根据以上，生成token
            var token = new JwtSecurityToken(
                jwtConfig.Issuer,     //Issuer
                jwtConfig.Audience,   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddDays(expires),   //expires
                signingCredentials               //Credentials
            );
            // 7. 将token变为string
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new LoginResDto
            {
                Token = $"Bearer {jwtToken}",
                UserInfo = userDetailInfoModel
            };
        }
    }
}
