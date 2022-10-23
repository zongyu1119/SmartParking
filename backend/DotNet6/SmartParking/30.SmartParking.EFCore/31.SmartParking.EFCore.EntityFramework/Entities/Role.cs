using System;
using System.Collections.Generic;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class Role : ParkingEntityBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string? RoleName { get; set; }
    }
}
