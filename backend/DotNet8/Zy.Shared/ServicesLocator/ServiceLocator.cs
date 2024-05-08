namespace Zy.Shared.ServicesLocator
{
    /// <summary>
    /// 单例实例
    /// </summary>
    public class ServiceLocator
    {
        /// <summary>
        ///  /// <summary>
        /// 只能获取Singleton/Transient，获取Scoped周期的对象会存与构造函数获取的不是相同对象
        /// </summary>
        /// </summary>
        public static IServiceProvider Instance { get; set; }
    }
}
