
namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 配置信息表
    /// </summary>
    public partial class Config : ParkingEntityBase
    {      
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
    }
}
