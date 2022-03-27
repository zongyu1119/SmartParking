using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 车辆进出历史表
    /// </summary>
    public partial class OpCarIo
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
        /// 进出流水ID
        /// </summary>
        public int IoId { get; set; }
        /// <summary>
        /// 进出类别（1:进;0:出）
        /// </summary>
        public string? IoType { get; set; }
        /// <summary>
        /// 进出地点类别(0:停车场;1:车位)
        /// </summary>
        public string? IoPlaceType { get; set; }
        /// <summary>
        /// 停车场ID
        /// </summary>
        public int? ParkingId { get; set; }
        /// <summary>
        /// 车位ID
        /// </summary>
        public int? PsId { get; set; }
        /// <summary>
        /// 车辆ID
        /// </summary>
        public int? CarId { get; set; }
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
