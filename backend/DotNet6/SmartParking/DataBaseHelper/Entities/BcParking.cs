using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场表
    /// </summary>
    public partial class BcParking
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
        /// 停车场ID
        /// </summary>
        public int ParkingId { get; set; }
        /// <summary>
        /// 停车场名称
        /// </summary>
        public string? ParkingName { get; set; }
        /// <summary>
        /// 停车场面积
        /// </summary>
        public string? ParkingArea { get; set; }
        /// <summary>
        /// 停车场类型（0：平面分区；1：条状分区；立体）
        /// </summary>
        public int? ParkingType { get; set; }
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
