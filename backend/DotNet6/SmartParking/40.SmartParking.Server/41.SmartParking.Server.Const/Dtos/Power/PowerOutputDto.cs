using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： PowerModel
///  Author: zy
///  Time:  2022-04-02 22:16:11
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.Power
{
    /// <summary>
    /// 权限模型
    /// </summary>
    public class PowerOutputDto
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public long PowerId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string? PowerName { get; set; }
        /// <summary>
        /// 权限路径
        /// </summary>
        public string? PowerPath { get; set; }
        /// <summary>
        /// 权限级别(多级权限区分权限级别)
        /// </summary>
        public int? PowerLevel { get; set; }
        /// <summary>
        /// 父权限ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 权限类型（0：菜单和功能；1：功能）
        /// </summary>
        public int? PowerType { get; set; }
    }
}
