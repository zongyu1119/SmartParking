using Zy.Shared.Entitys;

namespace Zy.User.Respository.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Comment("用户表")]
    [Table("sys_user")]
    public class SysUser: FullEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("name")]
        [Comment("姓名")]
        [Required(ErrorMessage = "姓名不可为空！")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string Name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Column("account")]
        [Comment("账号")]
        [Required(ErrorMessage = "账号不可为空！")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [Comment("密码")]
        [Required(ErrorMessage = "密码不可为空！")]
        [MaxLength(255, ErrorMessage = "最大不能超过255")]
        public string? Password { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        [Column("is_online")]
        [Comment("是否在线")]
        [Required(ErrorMessage = "是否在线不可为空！")]
        public bool IsOnline { get; set; } = false;

        /// <summary>
        /// 连接ID
        /// </summary>
        [Column("connection_id")]
        [Comment("连接ID")]
        [MaxLength(255, ErrorMessage = "最大不能超过255")]
        public string? ConnectionId { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [Column("address")]
        [Comment("住址")]
        [MaxLength(255, ErrorMessage = "最大不能超过255")]
        public string? Address { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        [Column("data_scope")]
        [Comment("数据权限")]
        [Required(ErrorMessage = "数据权限不可为空！")]
        [DefaultValue(DataScopeEnum.None)]
        public DataScopeEnum DataScope { get; set; }= DataScopeEnum.None;

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("user_id_card")]
        [Comment("身份证号")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string? UserIdCard { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("phone")]
        [Comment("手机号")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string? Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        [Comment("邮箱")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string? Email { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [Column("photo")]
        [Comment("照片")]
        [MaxLength(255, ErrorMessage = "最大不能超过255")]
        public string? Photo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("sex")]
        [Comment("性别")]
        [MaxLength(90, ErrorMessage = "最大不能超过90")]
        public string? Sex { get; set; }
    }
}