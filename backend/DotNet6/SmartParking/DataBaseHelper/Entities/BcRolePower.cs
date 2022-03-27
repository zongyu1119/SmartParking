using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 角色权限中间表
    /// </summary>
    public partial class BcRolePower
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
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerId { get; set; }
        /// <summary>
        /// 是否允许查询(1:允许;0:不允许)
        /// </summary>
        public int? IsSelect { get; set; }
        /// <summary>
        /// 是否允许新增(1:允许;0:不允许)
        /// </summary>
        public int? IsInsert { get; set; }
        /// <summary>
        /// 是否允许修改(1:允许;0:不允许)
        /// </summary>
        public int? IsUpdate { get; set; }
        /// <summary>
        /// 是否允许删除(1:允许;0:不允许)
        /// </summary>
        public int? IsDelete { get; set; }
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
