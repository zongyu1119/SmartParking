
namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 车位出租出售历史信息表
    /// </summary>
    public partial class OpParkingStatusHi : Entity
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
        /// 流水号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 车位ID
        /// </summary>
        public int PsId { get; set; }
        /// <summary>
        /// 出租出售对象(车主/业主表ID)
        /// </summary>
        public int? OwnerId { get; set; }
        /// <summary>
        /// 出租/出售价格(元)
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 出租/出售时长（天）
        /// </summary>
        public int? DurationTime { get; set; }
        /// <summary>
        /// 出租/出售类型（1：出租；2出售）
        /// </summary>
        public int? PsStatusType { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? ChangeTime { get; set; }
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
