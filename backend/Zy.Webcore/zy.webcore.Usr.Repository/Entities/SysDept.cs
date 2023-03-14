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
    /// 部门表
    /// </summary>
    [Table("sys_dept")]
    [Comment("部门表")]
    public class SysDept: FullAuditSoftDeleteInfo
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        [Column("dept_id")]
        [Comment("部门ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column("dept_name")]
        [Comment("部门名称")]
        [MaxLength(32, ErrorMessage = "部门名称不能大于64位！")]
        [Required(ErrorMessage = "部门名称不能为空！")]
        public string DeptName { get; set; }
        /// <summary>
        /// 父部门ID
        /// </summary>
        [Column("parent_dept_id")]
        [Comment("父部门ID")]
        public long ParentDeptId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("remark")]
        [MaxLength(256, ErrorMessage = "备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
