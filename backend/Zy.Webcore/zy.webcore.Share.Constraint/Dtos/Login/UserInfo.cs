
using ProtoBuf;
using zy.webcore.Share.Enum.Usr;
using zy.webcore.Share.Redis.Constraint;

namespace zy.webcore.Share.Constraint.Dtos.Login
{
    [Serializable]
    [ProtoContract]
    public class UserInfo:ICacheAble
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [ProtoMember(1)]
        public long UserId { get; set; }
        /// <summary>
        /// zhanghu
        /// </summary>
        [ProtoMember(2)]
        public string Account { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [ProtoMember(3)]
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 职务名称
        /// </summary>
        [ProtoMember(4)]
        public string JobName { get; set; } = null!;
        /// <summary>
        /// 用户身份证号
        /// </summary>
        [ProtoMember(5)]
        public string? UserIdCardNum { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        [ProtoMember(6)]
        public string? Sex { get; set; }
        /// <summary>
        /// 用户电话
        /// </summary>
        [ProtoMember(7)]
        public string? Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [ProtoMember(8)]
        public string? Address { get; set; }
        /// <summary>
        /// 数据权限
        /// </summary>
        [ProtoMember(9)]
        public DataScopeEnum DataScope { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [ProtoMember(10)]
        public string Email { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [ProtoMember(11)]
        public List<long> RoleIds { get; set; }
        /// <summary>
        /// 权限/菜单编码
        /// </summary>
        [ProtoMember(12)]
        public List<string> MenuCodeList { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        [ProtoMember(13)]
        public string Token { get; set; }
    }
}
