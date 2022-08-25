

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场分区表
    /// </summary>
    public partial class BcParkingArea : Entity
    {
        /// <summary>
        /// 租户号
        /// </summary>
        public int? TenantId { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
        /// <summary>
        /// 分区ID
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 分区名称
        /// </summary>
        public string? AreaName { get; set; }
        /// <summary>
        /// 分区编码
        /// </summary>
        public string? AreaCode { get; set; }
        /// <summary>
        /// 所属停车场ID
        /// </summary>
        public int? ParkingId { get; set; }
        /// <summary>
        /// 分区车位数
        /// </summary>
        public string? PsCount { get; set; }
        /// <summary>
        /// 分区地址
        /// </summary>
        public string? AreaAddress { get; set; }
        /// <summary>
        /// 分区序号（立体停车场为层数，平面停车场为排序）
        /// </summary>
        public int? AreaNo { get; set; }
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
