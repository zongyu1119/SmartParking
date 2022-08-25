using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class BcUserinfo : Entity
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
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
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
        public int? RoleId { get; set; }
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
