using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Params
///  Name： UserInfoParam
///  Author: zy
///  Time:  2022-04-02 22:50:53
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.User
{
    /// <summary>
    /// 查询用户信息的参数
    /// </summary>
    [Serializable]
    public class UserPageSearchDto: PageSearchDto
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public long? RoleId { get; set; }
    }
}
