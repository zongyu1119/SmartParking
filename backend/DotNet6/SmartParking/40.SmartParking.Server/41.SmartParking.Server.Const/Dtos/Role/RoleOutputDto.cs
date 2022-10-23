using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： RoleModel
///  Author: zy
///  Time:  2022-04-02 22:20:34
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.Role
{
    /// <summary>
    /// 角色模型
    /// </summary>
    public class RoleOutputDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string? RoleName { get; set; }
    }
}
