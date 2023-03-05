
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using zy.webcore.Share.Application.Service;
using zy.webcore.Share.Extensions;
using zy.webcore.Share.Options;

namespace zy.webcore.Usr.Application.Services
{
    /// <summary>
    /// JWT认证
    /// </summary>
    public class AuthorizeJWT : AbstractAppService, IAuthorizeJWT
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthorizeJWT> logger;
        private readonly IUserService service;
        /// <summary>
        /// JWT认证
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public AuthorizeJWT(IConfiguration _configuration, ILogger<AuthorizeJWT> _logger, IUserService _service)
        {
            this.configuration = _configuration;
            this.logger = _logger;
            this.service = _service;
        }
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <param name="bear"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<(bool, string?, UserDetailInfoDto?)> GetJWTBearAsync(AccountLoginDto user)
        {
            var jwtConfig = configuration.GetSection("JWT").Get<JwtOption>();
            string psdMd5 = GetPassword(user.Password);
            var userDetailInfoModel =await service.GetUserDetailInfoAsync(user.UserAccount);
            string errMsg = "";
            if(userDetailInfoModel == null)
            {
                logger.LogError("登录用户不存在！");
                errMsg = "登录用户不存在！";
                return (false,null,null);
            }
            if (userDetailInfoModel.Password != user.Password.GetMd5())
            {
                logger.LogError("用户名或密码错误！");
                errMsg = "用户名或密码错误！";
                return (false, null, null);
            }
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>()
            {
                new Claim("Id", userDetailInfoModel.UserId.ToString()),
                new Claim(ClaimTypes.Name, userDetailInfoModel.UserName),
                new Claim("Account", userDetailInfoModel.Account),
            };
         
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
           
            return (true, $"Bearer {jwtToken}", userDetailInfoModel);
        }
        /// <summary>
        /// 获得字符串的MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetPassword(string password)
        {
            return password.GetMd5();
        }
       
    }
}
