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
        /// <param name="expiry"></param>
        /// <returns>值</returns>
        Task<string> DistributedLock(string key,  int expiry = 10);
        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task DistributedUnLock(string key, string value);
    }
}
