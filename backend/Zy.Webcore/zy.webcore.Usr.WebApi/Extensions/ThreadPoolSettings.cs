namespace zy.webcore.Usr.WebApi.Extensions
{
    /// <summary>
    /// 线程池配置
    /// </summary>
    public class ThreadPoolSettings
    {
        /// <summary>
        /// 最小线程数
        /// </summary>
        /// <value>默认300</value>
        public int MinThreads { get; set; } = 300;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int MinCompletionPortThreads { get; set; } = 300;
        /// <summary>
        /// 最大线程数
        /// </summary>
        /// <value></value>
        public int MaxThreads { get; set; } = 32767;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int MaxCompletionPortThreads { get; set; } = 1000;
    }
}
