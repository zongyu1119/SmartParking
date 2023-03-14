using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Repository.EntitiesBase;

namespace zy.webcore.Usr.Repository.Entities
{
    /// <summary>
    /// 用户职务表(用户-部门-职务)
    /// 用户可以有多个职务，多个职务可以在多个部门
    /// </summary>
    [Table("sys_user_job")]
    [Comment("用户职务表")]
    public class SysUserJob : FullAuditInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        [Column("user_job_id")]
        [Comment("ID")]
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 部门ID
        /// </summary>
        [Comment("部门ID")]
        [Column("dept_id")]
        public long DeptId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Comment("用户ID")]
        [Column("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 职务ID
        /// </summary>
        [Column("job_id")]
        [Comment("职务ID")]
        public long? JobId { get; set; }
        /// <summary>
        /// 是否主要职务
        /// </summary>
        [Column("is_main_job")]
        [Comment("是否主要职务")]
        public bool IsMainJob { get; set; }=true;
        /// <summary>
        /// 是否部门管理者
        /// </summary>
        [Column("is_manager")]
        [Comment("是否部门管理者")]
        public bool IsManager { get; set; }=false;
        /// <summary>
        /// 是否部门管理者
        /// </summary>
        [Column("is_main_manager")]
        [Comment("是否部门主要管理者（正职）")]
        public bool IsMainManager { get; set; } = false;
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("remark")]
        [MaxLength(256, ErrorMessage = "备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
