using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.share.Repository.EntitiesBase;

namespace zy.webcore.Usr.Repository.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("sys_role")]
    [Comment("角色表")]
    public class SysRole: FullAuditInfo
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Comment("角色ID")]
        [Column("role_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name")]
        [Comment("角色名称")]
        [MaxLength(32,ErrorMessage ="角色名称不能大于32位！")]
        public string RoleName { get; set; }
    }
}
