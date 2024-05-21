using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Zy.Message.Constraint.Dtos;
using Zy.Message.Repository.Entitys;
using Zy.Shared.Repository.Contexts;
using Zy.Shared.Extensions;
using Zy.Message.Constraint.IServices;
using Zy.Shared.Service.Services;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Cache.Services;
namespace Zy.Message.Services.AppServices
{
    /// <summary>
    /// 用户登录验证服务
    /// </summary>
    public class SessionService(
        GenerateJwtService generateJwt,
        IEfRepository<User> efRepository,
        ICacheService cacheService) :AbstractService, ISessionService
    {
        public async Task<ZyResult<JwtTokenResult>> SessionAsync(LoginDto loginDto, ClientTypeEnum clientType= ClientTypeEnum.PC)
        {
            var user = await efRepository.FirstOrDefaultAsync(x => x.Account == loginDto.Account);
            if (user == null)
                return Problem<JwtTokenResult>(System.Net.HttpStatusCode.BadRequest,"用户不存在！");
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
                UserIdCardNum = user.UserIdCardNum
            };
            await cacheService.SetAsync<UserInfoCacheAble>(cacheKey, userInfoCache);
            return (jwtTokenResult);
        }
    }
}
