using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场管理员表
    /// </summary>
    public partial class ParkingManager : ParkingEntityBase
    {
      
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string ManagerName { get; set; } = null!;
        /// <summary>
        /// 管理员身份证号
        /// </summary>
        public string? ManagerIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
    }
}
