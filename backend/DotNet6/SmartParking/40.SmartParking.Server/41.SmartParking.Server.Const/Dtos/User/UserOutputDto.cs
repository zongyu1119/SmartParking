using SmartParking.Server.Const.Dtos.DtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： UserInfo
///  Author: zy
///  Time:  2022-04-02 22:40:12
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.User
{
    public class UserOutputDto : OutputDto
    {
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
        public long? RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string? RoleName { get; set; }
    }
}
