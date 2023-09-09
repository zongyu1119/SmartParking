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
    /// 角色权限表
    /// </summary>
    [Table("sys_role_menu")]
    [Comment("角色权限表")]
    public class SysRoleMenu : FullAuditInfo
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Comment("ID")]
        [Column("role_menu_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        [Comment("角色ID")]
        public long RoleId { get;set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        [Column("menu_id")]
        [Comment("权限ID")]
        public long MenuId { get; set; }
    }
}
