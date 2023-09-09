namespace zy.webcore.Share.Application.Service
{
    /// <summary>
    /// 用户登录Service
    /// </summary>
    public class BaseAccountService:AbstractAppService
    {
        protected readonly ICacheService _cacheService;
        protected readonly JwtOption _jwtConfig;
        public BaseAccountService(ICacheService cacheService,IConfiguration configuration) {
            _cacheService= cacheService;
            _jwtConfig = configuration.GetSection("JWT").Get<JwtOption>();
        }
        /// <summary>
        /// 设置登录用户缓存
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
       private async Task SetUserInfoCacheAsync(UserInfo userInfo, ClientTypeEnum clientType)
        {
            var cacheKey = CacheKeyConsts.userLoginObjCacheKeyPrefix + ":"+clientType.GetDescription()+":" + userInfo.UserId;
            await _cacheService.SetAsync<UserInfo>(cacheKey, userInfo,_jwtConfig.Expires*24*60*60);
        }
        /// <summary>
        /// 获得token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        protected virtual async Task GetJwtTokenAsync(UserInfo userInfo, ClientTypeEnum clientType = ClientTypeEnum.PC)
        {
            // 1. 定义需要使用到的Claims
            var claims = new List<Claim>()
            {
                new Claim("Id", userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim("Account", userInfo.Account),
                new Claim("ClientType",((int)clientType).ToString())
            };
            if (userInfo.Email != null)
                claims.Add(new Claim(ClaimTypes.Email, userInfo.Email));
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
            userInfo.Token = jwtToken;
            await this.SetUserInfoCacheAsync(userInfo,clientType);
        }
    }
}
