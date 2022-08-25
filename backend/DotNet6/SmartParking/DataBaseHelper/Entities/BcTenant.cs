using Common.Entity;
using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 租户表
    /// </summary>
    public partial class BcTenant : Entity
    {
        /// <summary>
        /// 租户号
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int? Revision { get; set; }
        /// <summary>
        /// 租户名称
        /// </summary>
        public string? TenantName { get; set; }
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
