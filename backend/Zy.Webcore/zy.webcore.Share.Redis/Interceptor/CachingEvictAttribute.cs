namespace zy.webcore.Share.Redis.Interceptor
{
    /// <summary>
    /// Redis evict attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingEvictAttribute : CachingInterceptorAttribute
    {
        /// <summary>
        /// The cache keys
        /// </summary>
        public string[] CacheKeys { get; set; } = new string[] { };
    }
}
