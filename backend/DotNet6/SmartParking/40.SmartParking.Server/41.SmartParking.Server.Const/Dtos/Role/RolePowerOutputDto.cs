using SmartParking.Server.Const.Dtos.DtoBase;
using SmartParking.Server.Const.Dtos.Power;
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

namespace SmartParking.Server.Const.Dtos.Role
{
    public class RolePowerOutputDto : OutputDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public long PowerId { get; set; }
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
        public PowerOutputDto? Power { get; set; }
    }
}
