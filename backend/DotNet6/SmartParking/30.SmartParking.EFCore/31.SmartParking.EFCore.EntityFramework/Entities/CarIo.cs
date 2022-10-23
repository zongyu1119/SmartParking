using System;
using System.Collections.Generic;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 车辆进出历史表
    /// </summary>
    public partial class CarIo : ParkingEntityBase
    {
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
    }
}
