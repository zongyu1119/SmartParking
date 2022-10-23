using Microsoft.IdentityModel.Tokens;
using SmartParking.ViewModels;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using SmartParking.Server.Const.Dtos.User;
using SmartParking.Server.Const.Dtos.DtoBase;

namespace SmartParking.Authorize
{
    /// <summary>
    /// JWT认证
    /// </summary>
    public class AuthorizeJWT : IAuthorizeJWT
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthorizeJWT> logger;
        private readonly IUserInfoService service;
        /// <summary>
        /// JWT认证
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public AuthorizeJWT(IConfiguration _configuration, ILogger<AuthorizeJWT> _logger, IUserInfoService _service)
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
        public async Task<ResDto<(string bear, UserDetailOutputDto user)>> GetJWTBear(UserLoginArgs user)
        {
            string psdMd5 = GetPassword(user.Password);
            var userRes = await service.GetUserDetailInfoAsync(user.UserName);
            if (!userRes.Success)
            {
                return new ResDto<ValueTuple<string, UserDetailOutputDto>>(default, "登录用户不存在！");
            }           
            var bear = string.Empty;
            if (userRes.Data.Password != user.Password.GetMd5())
            {
                return new ResDto<ValueTuple<string, UserDetailOutputDto>>(default, "用户名或密码错误！");
            }
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>()
            {
                new Claim("Id", userRes.Data.UserId.ToString()),
                new Claim(ClaimTypes.Name, userRes.Data.UserName),
                new Claim("UserNameRel", userRes.Data.UserNameRel),
                new Claim("TenantId",userRes.Data.TenantId.ToString()),
                new Claim("RoleId",userRes.Data.RoleId.ToString()),
            };
            if (userRes.Data.RolePowers != null)
            {
                userRes.Data.RolePowers.ForEach(p =>
                {
                    if (p.IsDelete != null && p.IsDelete == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, $"{PowerType.Delete}:{p.PowerId}"));
                    }
                    if (p.IsSelect != null && p.IsSelect == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, $"{PowerType.Select}:{p.PowerId}"));
                    }
                    if (p.IsInsert != null && p.IsInsert == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, $"{PowerType.Insert}:{p.PowerId}"));
                    }
                    if (p.IsUpdate != null && p.IsUpdate == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, $"{PowerType.Update}:{p.PowerId}"));
                    }
                });
            }

            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;

            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);

            // 5. 从 appsettings.json 中读取Expires
            var expires = Convert.ToDouble(configuration["JWT:Expires"]);


            // 6. 根据以上，生成token
            var token = new JwtSecurityToken(
                configuration["JWT:Issuer"],     //Issuer
                configuration["JWT:Audience"],   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddDays(expires),   //expires
                signingCredentials               //Credentials
            );

            // 7. 将token变为string
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            bear= "Bearer " + jwtToken;
            return new ResDto<ValueTuple<string, UserDetailOutputDto>>((bear,userRes.Data)); 
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
