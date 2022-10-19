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

namespace Service.Params
{
    /// <summary>
    /// 查询用户信息的参数
    /// </summary>
    [Serializable]
    public class UserInfoQueryParam: ParamBase
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int? RoleId { get; set; }
    }
}
