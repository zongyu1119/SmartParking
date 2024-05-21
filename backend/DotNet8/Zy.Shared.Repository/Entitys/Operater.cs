namespace Zy.Shared.Entitys
{
    /// <summary>
    /// 操作者
    /// </summary>
    public class Operater
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = default!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = default!;
    }
}
