using System;
using System.Collections.Generic;

namespace SmartParking.EFCore.EntityFramework.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class Userinfo : ParkingEntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string? UserNameRel { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string? UserIdCardNum { get; set; }
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
        /// <summary>
        /// 权限ID
        /// </summary>
        public long? RoleId { get; set; }
    }
}
