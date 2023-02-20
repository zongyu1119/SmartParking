using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zy.webcore.share.Repository.EntitiesBase;

namespace zy.webcore.Usr.Repository.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("sys_user")]
    [Comment("用户表")]
    public partial class SysUserinfo:FullAuditInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("account")]
        [Comment("用户账户")]
        [MaxLength(32)]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [Comment("Password")]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [Column("user_name")]
        [Comment("用户姓名")]
        public string? UserName { get; set; }
        /// <summary>
        /// 职务ID
        /// </summary>
        [Column("user_job")]
        [Comment("职务")]
        public long? JobId { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        [Column("user_id_card_num")]
        [Comment("身份证号")]
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [Column("sex")]
        [Comment("性别")]
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [Column("phone")]
        [Comment("电话号码")]
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [Column("address")]
        [Comment("住址")]
        public string? Address { get; set; }
    }
}
