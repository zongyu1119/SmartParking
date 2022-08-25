
namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 配置信息表
    /// </summary>
    public partial class BcConfig : Entity
    {
        /// <summary>
        /// 租户号
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
        /// <summary>
        /// 配置项类别
        /// </summary>
        public string ConfigSort { get; set; } = null!;
        /// <summary>
        /// 配置项键
        /// </summary>
        public string ConfigKey { get; set; } = null!;
        /// <summary>
        /// 配置项序号（某个键下得序号）
        /// </summary>
        public string ConfigOrder { get; set; } = null!;
        /// <summary>
        /// 配置项值
        /// </summary>
        public string? ConfigValue { get; set; }
        /// <summary>
        /// 配置项备注
        /// </summary>
        public string? ConfigRemark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreatedBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}
