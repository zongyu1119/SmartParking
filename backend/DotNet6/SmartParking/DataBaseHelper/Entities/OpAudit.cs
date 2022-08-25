using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: DataBaseHelper.Entities
///  Name： OpAudit
///  Author: zy
///  Time:  2022-04-10 21:54:54
///  Version:  0.1
/// </summary>

namespace DataBaseHelper.Entities
{
    /// <summary>
    /// 审计相关表
    /// </summary>
    [Table("op_audit")]    
    public class OpAudit : Entity
    {
        /// <summary>
        /// 租户号
        /// </summary>
        [Column("TENANT_ID")]
        [Comment("租户号")]
        public int? TenantId { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        [Comment("乐观锁")]
        [Column("REVISION")]
        public int? Revision { get; set; }
        /// <summary>
        /// 审计ID
        /// </summary>
        [Key]
        [Column("ID")]
        [Comment("ID")]
        public int Id { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        [Column("TYPE",TypeName = "varchar")]
        [MaxLength(16)]
        [Comment("操作类型")]
        public string? Type { get; set; }
        /// <summary>
        /// 操作的方法名
        /// </summary>
        [Column("ACTION_NAME",TypeName = "varchar")]
        [MaxLength(255)]
        [Comment("操作方法名")]
        public string? ActionNmae { set; get; }
        /// <summary>
        /// 操作说明
        /// </summary>
        [Comment("操作说明")]
        [Column("DESCRIPTION",TypeName = "varchar")]
        [MaxLength(512)]
        public string? Description { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        [Comment("操作用户")]
        [Column("CREATE_BY")]
        public int? CreatedBy { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Comment("操作时间")]
        [Column(name:"CREATE_TIME", TypeName= "datetime")]
        public DateTime? CreatedTime { get; set; }
    }
}
