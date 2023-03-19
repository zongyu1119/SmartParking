namespace zy.webcore.Share.DistributedLock.Register
{
    /// <summary>
    /// 注册分布式锁
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册分布式锁
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddDistributeLockService(this IServiceCollection service)
        {
            service.AddSingleton(typeof(IDistributedLockService),typeof(DistributedLockService));
            return service;
        }
    }
}
