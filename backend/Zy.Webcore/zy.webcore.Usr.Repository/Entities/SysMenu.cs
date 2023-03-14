using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Repository.EntitiesBase;
using zy.webcore.Share.Enum.Usr;

namespace zy.webcore.Usr.Repository.Entities 
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Comment("菜单表")]
    [Table("sys_menu")]
    public class SysMenu : FullAuditSoftDeleteInfo
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Comment("菜单ID")]
        [Column("menu_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Column("menu_name")]
        [Comment("菜单名称")]
        [MaxLength(32, ErrorMessage = "菜单名称不能大于64位！")]
        [Required(ErrorMessage ="菜单名称不能为空！")]
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Comment("菜单编码")]
        [Column("menu_code")]
        [MaxLength(64,ErrorMessage ="菜单编码不能大于64位！")]
        [Required(ErrorMessage ="菜单编码不能为空！")]
        public string MenuCode { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Comment("是否启用")]
        [Column("enable")]
        [MaxLength(1)]
        public bool Enable { get; set; }=true;
        /// <summary>
        /// 菜单路径
        /// </summary>
        [Comment("菜单路径")]
        [Column("menu_path")]
        [MaxLength(128,ErrorMessage ="菜单路径不能大于128个字符！")]
        [AllowNull]
        public string MenuPath { get; set; } = null;
        /// <summary>
        /// 是否启用
        /// </summary>
        [Comment("菜单类型")]
        [Column("menu_type")]
        [Required]
        public MenuTypeEnum MenuType { get; set; }=MenuTypeEnum.Directory;
        /// <summary>
        /// 排序
        /// </summary>
        [Comment("父菜单")]
        [Column("parent_menu_id")]
        public long? ParentMenuId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        [Column("order")]
        [Required]
        public int Order { get; set; }=0;
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("remark")]
        [MaxLength(255,ErrorMessage ="备注不允许超过255字！")]
        public string? Remark { get; set; }
    }
}
