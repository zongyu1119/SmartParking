
namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 车位出租出售历史信息表
    /// </summary>
    public partial class ParkingStatusHi : ParkingEntityBase
    {       
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
    }
}
