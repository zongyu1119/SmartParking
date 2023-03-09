using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Usr.Constraint.Dtos.Account
{
    /// <summary>
    /// 登录返回数据
    /// </summary>
    public class LoginResDto
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserDetailInfoDto UserInfo { get; set; }
    }
    public class UserDetailInfoDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// zhanghu
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 职务名称
        /// </summary>
        public string JobName { get; set; } = null!;    
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
        /// 角色ID
        /// </summary>
        public List<long> RoleIds { get; set; }
        /// <summary>
        /// 权限/菜单编码
        /// </summary>
        public List<MenuOutputDto>? MenuList { get; set; }
    }
}
