using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.DistributedLock.Services
{
    /// <summary>
    /// 分布式锁
    /// </summary>
    public interface IDistributedLockService
    {
        /// <summary>
        /// 上锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="autoRenewal"></param>
        /// <returns>值</returns>
        Task<long> DistributedLock(string key, bool autoRenewal=false);
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task DistributedUnLock(string key, string value);
    }
}
