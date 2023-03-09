using zy.webcore.Share.Constraint.Dtos.Login;
using zy.webcore.Share.Consts.Usr;

namespace zy.webcore.Usr.Application.Services
{
    /// <summary>
    /// JWT认证
    /// </summary>
    public class AccountService : BaseAccountService, IAccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly IUserService service;
        /// <summary>
        /// JWT认证
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public AccountService(IConfiguration configuration, 
            ILogger<AccountService> _logger,
            IUserService _service, ICacheService cacheService):base(cacheService, configuration)
        {
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
            var userDetailInfoModel = await service.GetUserDetailInfoAsync(user.UserAccount);
            if (userDetailInfoModel == null)
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
            var userinfo = new UserInfo
            {
                Account = userDetailInfoModel.Account,
                Address = userDetailInfoModel.Address,
                JobName = userDetailInfoModel.JobName,
                MenuCodeList = userDetailInfoModel?.MenuList?.Select(x => x.MenuCode).ToList()??new List<string>(),
                Phone = userDetailInfoModel?.Phone,
                RoleIds = userDetailInfoModel.RoleIds??new List<long>(),
                Sex = userDetailInfoModel.Sex,
                UserId = userDetailInfoModel.UserId,
                UserIdCardNum = userDetailInfoModel.UserIdCardNum,
                UserName = userDetailInfoModel.UserName,
            };
            var jwtToken = GetJwtToken(userinfo);
            userinfo.Token = jwtToken;
            //TODO 设置缓存时类型出现错误
            await base.SetUserInfoCacheAsync(userinfo);
            return new LoginResDto
            {
                Token = $"Bearer {jwtToken}",
                UserInfo = userDetailInfoModel
            };
        }
        /// <summary>
        /// 获得token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="jwtConfig"></param>
        /// <returns></returns>
        protected override string GetJwtToken(UserInfo userInfo)
        {           
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>()
            {
                new Claim("Id", userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim("Account", userInfo.Account)
            };
            if (userInfo.RoleIds != null && userInfo.RoleIds.Any())
                userInfo.RoleIds.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.ToString())));
            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;
            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            // 5. 从 appsettings.json 中读取Expires
            var expires = Convert.ToDouble(_jwtConfig.Expires);
            // 6. 根据以上，生成token
            var token = new JwtSecurityToken(
                _jwtConfig.Issuer,     //Issuer
                _jwtConfig.Audience,   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddDays(expires),   //expires
                signingCredentials               //Credentials
            );
            // 7. 将token变为string
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

    }
}
