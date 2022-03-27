using Microsoft.IdentityModel.Tokens;
using SmartParking.ViewModels;
using System.Security.Claims;
using DataBaseHelper.Entities;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace SmartParking.Authorize
{
    public class AuthorizeJWT : IAuthorizeJWT
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthorizeJWT> _logger;
        private smartparkingContext _dbContext;
        public AuthorizeJWT(IConfiguration configuration, ILogger<AuthorizeJWT> logger, smartparkingContext dbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _dbContext = dbContext;
        }
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetJWTBear(UserLogin user)
        {
            string psdMd5 = GetPassword(user.Password);
            BcUserinfo userinfo=_dbContext.BcUserinfos.FirstOrDefault(x => x.UserName == user.UserName&&x.Password==psdMd5);
            if(userinfo == null)
            {
                _logger.LogError("用户名或密码错误");
                return null;
            }
            // 1. 定义需要使用到的Claims
            var claims = new[]
            {
                new Claim("Id", userinfo.UserId.ToString()),
                new Claim("Name", userinfo.UserName),
                new Claim(ClaimTypes.Role,"1"),
            };

            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;

            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);

            // 5. 从 appsettings.json 中读取Expires
            var expires = Convert.ToDouble(_configuration["JWT:Expires"]);


            // 6. 根据以上，生成token
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],     //Issuer
                _configuration["JWT:Audience"],   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddDays(expires),   //expires
                signingCredentials               //Credentials
            );

            // 7. 将token变为string
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return "Bearer " + jwtToken;
        }
        /// <summary>
        /// 获得字符串的MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static string GetPassword(string password)
        {
            MD5 md5Hasher = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
