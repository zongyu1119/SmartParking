﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zy.webcore.Share.Repository.EntitiesBase;
using zy.webcore.Share.Enum.Usr;

namespace zy.webcore.Usr.Repository.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("sys_user")]
    [Comment("用户表")]
    public partial class SysUser: FullAuditSoftDeleteInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长
        [Column("user_id")]
        [Comment("ID")]
        public override long Id { get => base.Id; set => base.Id = value; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("account")]
        [Comment("用户账户")]
        [MaxLength(32,ErrorMessage ="用户账户不能超过32个字！")]
        public string Account { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [Comment("密码")]
        [MaxLength(255, ErrorMessage = "用户密码不能超过255个字！")]
        public string Password { get; set; } = null!;
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [Column("user_name")]
        [Comment("用户姓名")]
        [MaxLength(32, ErrorMessage = "用户姓名不能超过32个字！")]
        public string? UserName { get; set; }
      
        /// <summary>
        /// 用户身份证号
        /// </summary>
        [Column("user_id_card_num")]
        [Comment("身份证号")]
        [MaxLength(32, ErrorMessage = "身份证号不能超过32个字！")]
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [Column("sex")]
        [Comment("性别")]
        [MaxLength(4, ErrorMessage = "性别不能超过4个字！")]
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [Column("phone")]
        [Comment("电话号码")]
        [MaxLength(32, ErrorMessage = "电话不能超过32个字！")]
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [Column("address")]
        [Comment("住址")]
        [MaxLength(255, ErrorMessage = "住址不能超过255个字！")]
        public string? Address { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        [Comment("数据权限")]
        [Column("data_scope")]
        public DataScopeEnum DataScope { get; set; } = DataScopeEnum.None;
        /// <summary>
        /// 邮箱
        /// </summary>
        [Comment("邮箱")]
        [Column("email")]
        [MaxLength(128,ErrorMessage ="邮箱不能超过128位！")]
        public string? Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        [Column("remark")]
        [MaxLength(256,ErrorMessage ="备注不能大于256位!")]
        public string? Remark { get; set; }
    }
}
