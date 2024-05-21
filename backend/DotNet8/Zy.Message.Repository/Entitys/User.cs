using ProtoBuf;
using Zy.Shared.Enums;

namespace Zy.Message.Repository.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("user")]
    public class User: FullEntity
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Column("name")]
        [MaxLength(255,ErrorMessage ="最大不能超过")]
        [Comment("名称")]
        [Required(ErrorMessage ="不可为空！")]
        [DefaultValue(null)]
        public string Name { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        [Column("account")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        [Comment("数据权限")]
        [DefaultValue(0)]
        [Column("data_scope")]
        public DataScopeEnum DataScope { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        [Column("is_online")]
        public bool IsOnline { get; set; }
        /// <summary>
        /// 连接ID
        /// </summary>
        [Column("connection_id")]
        public string? ConectionId { get; set; }
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        public string Email { get; set; }
    }
}
