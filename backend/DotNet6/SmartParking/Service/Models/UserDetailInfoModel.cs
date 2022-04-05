using DataBaseHelper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： UserInfo
///  Author: zy
///  Time:  2022-04-02 22:07:55
///  Version:  0.1
/// </summary>

namespace Service.Models
{
    /// <summary>
    /// 用户详细信息
    /// </summary>
    public class UserDetailInfoModel
    {
        /// <summary>
        /// 租户号
        /// </summary>
        public int? TenantId { get;set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = null!;
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string? UserNameRel { get; set; }
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
        public int? RoleId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public RoleModel? Role { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public List<RolePowerModel>? RolePowers { get; set; }
    }
}
