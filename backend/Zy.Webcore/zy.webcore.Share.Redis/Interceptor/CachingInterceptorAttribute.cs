using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Redis.Interceptor
{
    /// <summary>
    /// Redis interceptor attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingInterceptorAttribute : Attribute
    {
        /// <summary>
        /// 缓存键前缀
        /// </summary>
        public string CacheKeyPrefix { get; set; } = string.Empty;

        /// <summary>
        ///  防止缓存提供程序错误影响业务
        /// </summary>
        public bool IsHighAvailability { get; set; } = true;

        /// <summary>
        /// 缓存键
        /// </summary>
        public string CacheKey { get; set; } = string.Empty;
    }
}
