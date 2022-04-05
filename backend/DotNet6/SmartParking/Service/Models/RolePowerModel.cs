using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： RolePowerModel
///  Author: zy
///  Time:  2022-04-02 22:14:37
///  Version:  0.1
/// </summary>

namespace Service.Models
{
    public class RolePowerModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerId { get; set; }
        /// <summary>
        /// 是否允许查询(1:允许;0:不允许)
        /// </summary>
        public int? IsSelect { get; set; }
        /// <summary>
        /// 是否允许新增(1:允许;0:不允许)
        /// </summary>
        public int? IsInsert { get; set; }
        /// <summary>
        /// 是否允许修改(1:允许;0:不允许)
        /// </summary>
        public int? IsUpdate { get; set; }
        /// <summary>
        /// 是否允许删除(1:允许;0:不允许)
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// 权限信息
        /// </summary>
        public PowerModel? Power { get; set; }
    }
}
