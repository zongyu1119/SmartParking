using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Cache.Services;
using zy.webcore.Share.Constraint.Dtos.Login;
using zy.webcore.Share.Consts.Usr;
using zy.webcore.Share.Options;

namespace zy.webcore.Share.Application.Service
{
    /// <summary>
    /// 用户登录Service
    /// </summary>
    public abstract class BaseAccountService:AbstractAppService
    {
        private readonly ICacheService _cacheService;
        public BaseAccountService(ICacheService cacheService) {
            _cacheService= cacheService;
        }
        /// <summary>
        /// 设置用户缓存
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
       public async Task SetUserInfoCacheAsync(UserInfo userInfo)
        {
            var cacheKey = CacheKeyConsts.userLoginObjCacheKeyPrefix + ":" + userInfo.UserId;
            await _cacheService.SetAsync(cacheKey, userInfo);
        }
        /// <summary>
        /// 获得token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        protected abstract string GetJwtToken(UserInfo userInfo);
    }
}
