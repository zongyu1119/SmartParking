using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 权限表
    /// </summary>
    public partial class BcPower : Entity
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
        /// 权限ID
        /// </summary>
        public int PowerId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string? PowerName { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string? PowerPath { get; set; }
        /// <summary>
        /// 权限级别(多级权限区分权限级别)
        /// </summary>
        public int? PowerLevel { get; set; }
        /// <summary>
        /// 父权限ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 权限类型（0：菜单和功能；1：功能）
        /// </summary>
        public int? PowerType { get; set; }
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
