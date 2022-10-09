﻿

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场分区表
    /// </summary>
    public partial class ParkingArea : ParkingEntityBase
    {       
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
    }
}