using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Redis.Interceptor
{
    /// <summary>
    /// Cachable.
    /// </summary>
    public interface ICachable
    {
        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <value>The cache key.</value>
        string CacheKey { get; }
    }
}
