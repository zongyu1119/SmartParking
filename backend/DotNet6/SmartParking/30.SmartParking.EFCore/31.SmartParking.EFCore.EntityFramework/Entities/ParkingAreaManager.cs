using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场分区与管理员对应关系表(多对多关系)
    /// </summary>
    public partial class ParkingAreaManager : ParkingEntityBase
    {      
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// 停车场分区ID
        /// </summary>
        public int ParkingAreaId { get; set; }
    }
}
