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
    /// 用户角色表
    /// </summary>
    [Table("sys_user_role")]
    [Comment("用户角色表")]
    public class SysUserRole : FullAuditInfo
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Comment("ID")]
        [Column("user_role_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 权限ID
        /// </summary>
        [Column("user_id")]
        [Comment("用户ID")]
        public long UserId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        [Comment("角色ID")]
        public long RoleId { get; set; }
       
    }
}
