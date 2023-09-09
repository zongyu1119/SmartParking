namespace zy.webcore.Share.Application.Caching
{
    public interface ICachePreheatable
    {
        /// <summary>
        /// 预热缓存
        /// </summary>
        /// <returns></returns>
        Task PreheatAsync();
    }
}
