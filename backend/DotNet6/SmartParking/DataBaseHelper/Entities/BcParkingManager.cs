using System;
using System.Collections.Generic;

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 停车场管理员表
    /// </summary>
    public partial class BcParkingManager : Entity
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
        /// 车主/业主ID
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// 车主名
        /// </summary>
        public string ManagerName { get; set; } = null!;
        /// <summary>
        /// 用户身份证号
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
