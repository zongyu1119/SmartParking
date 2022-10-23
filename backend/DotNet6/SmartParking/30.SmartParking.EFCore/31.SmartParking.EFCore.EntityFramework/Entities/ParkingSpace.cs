using System;
using System.Collections.Generic;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 车位表
    /// </summary>
    public partial class ParkingSpace : ParkingEntityBase
    {
        /// <summary>
        /// 车位编码
        /// </summary>
        public string? PsCode { get; set; }
        /// <summary>
        /// 所属停车场区域
        /// </summary>
        public string? ParkingAreaId { get; set; }
        /// <summary>
        /// 车位类型（0：普通车位；1：无障碍车位）
        /// </summary>
        public int? PsType { get; set; }
        /// <summary>
        /// 车位面积
        /// </summary>
        public decimal? PsArea { get; set; }
        /// <summary>
        /// 子母车位(0:标准车位；1：子母车位；)
        /// </summary>
        public int? PsLash { get; set; }
        /// <summary>
        /// 是否有充电桩（0：无；1：有）
        /// </summary>
        public string? PsCharg { get; set; }
        /// <summary>
        /// 车位当前出租出售状态（0：普通车位；1：长租车位；2：：已经出售）
        /// </summary>
        public string? PsRentStatus { get; set; }
        /// <summary>
        /// 车位当前归属（租受人/业主）
        /// </summary>
        public string? PsOwner { get; set; }
        /// <summary>
        /// 租期截止时间
        /// </summary>
        public DateTime? RentEndTime { get; set; }
        /// <summary>
        /// 车位占用状态（0：空闲；1：占用）
        /// </summary>
        public int? OccupyStatus { get; set; }
        /// <summary>
        /// 占用车辆ID
        /// </summary>
        public int? CarId { get; set; }
        /// <summary>
        /// 占用起始时间
        /// </summary>
        public DateTime? OccupyStartTime { get; set; }
    }
}
