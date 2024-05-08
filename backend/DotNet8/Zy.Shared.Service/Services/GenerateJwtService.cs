using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Shared.Service.Services
{
    public class GenerateJwtService
    {
        private readonly JwtConfig _jwtConfig;
        public GenerateJwtService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }
        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="customClaims">携带的用户信息</param>
        /// <returns></returns>
        public JwtTokenResult GenerateEncodedTokenAsync(LoginUserModel customClaims)
        {
            //创建用户身份标识，可按需要添加更多信息
            var claims = new List<Claim>
            {
                new Claim("userid", customClaims.UserId.ToString()),
                new Claim(ClaimTypes.Name, customClaims.Name),
                new Claim("account",customClaims.Account)
            };
            //创建令牌
            var jwt = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                notBefore: _jwtConfig.NotBefore,
                expires: _jwtConfig.Expiration,
                signingCredentials: _jwtConfig.SigningCredentials);
            string access_token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtTokenResult()
            {
                AccessToken = access_token,
                ExpiresIn = _jwtConfig.Expired * 60,
                User = customClaims
            };
        }
    }
}
