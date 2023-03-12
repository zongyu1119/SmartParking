using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Consts.Usr
{
    public static class CacheKeyConsts
    {
        /// <summary>
        /// 保存用户登录信息的缓存前缀
        /// </summary>
        public const string userLoginObjCacheKeyPrefix = "zy:webcore:usr:login";
       
        /// <summary>
        /// 验证码缓存前缀
        /// </summary>
        public const string userCaptchCacheKeyPrefix = "zy:webcore:usr:login:captch";
    }
}
