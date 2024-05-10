



namespace Zy.User.Services.AppServices
{
    /// <summary>
    /// 用户登录验证服务
    /// </summary>
    public class SessionService(GenerateJwtService generateJwt,
        IEfRespository<SysUser> efRespository,
        ICacheService cacheService,
        ILogger<SessionService> logger) :AbstractService, ISessionService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <param name="clientType"></param>
        /// <returns></returns>
        public async Task<ZyResult<JwtTokenResult>> SessionAsync(SessionDto loginDto, ClientTypeEnum clientType= ClientTypeEnum.PC)
        {
            logger.LogInformation($"登录：{loginDto.Account}");
            var user = await efRespository.FirstOrDefaultAsync(x => x.Account == loginDto.Account);
            if (user == null)
                return Problem<JwtTokenResult>(System.Net.HttpStatusCode.BadRequest, "用户不存在！");
            var md5 = loginDto.Password.MD5Encrypt32();
            if (md5 != user.Password)
                return Problem<JwtTokenResult>(System.Net.HttpStatusCode.BadRequest, "用户名或密码错误！");
            var claims = new LoginUserModel()
            {
                Name = user.Name,
                Account = loginDto.Account,
                UserId=user.Id
            };
            var refreshToken = Guid.NewGuid().ToString();
           
            var jwtTokenResult = generateJwt.GenerateEncodedTokenAsync(claims);
            jwtTokenResult.RefreshToken = refreshToken;
            var cacheKey = CacheKeyConsts.userLoginObjCacheKeyPrefix + ":" + clientType.GetDescription() + ":" + user.Id;
            var userInfoCache = new UserInfoCacheAble
            {
                Account = loginDto.Account,
                DataScope = user.DataScope,
                Email = user.Email,
                Phone = user.Phone,
                Sex = user.Sex,
                UserId = user.Id,
                Token = jwtTokenResult.AccessToken,
                UserName = user.Name,
            };
            await cacheService.SetAsync<UserInfoCacheAble>(cacheKey, userInfoCache);
            return jwtTokenResult;
        }
    }
}
