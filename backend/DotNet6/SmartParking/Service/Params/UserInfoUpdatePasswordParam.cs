using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Params
///  Name： UserInfoUpdatePasswordParam
///  Author: zy
///  Time:  2022-04-05 11:07:30
///  Version:  0.1
/// </summary>

namespace Service.Params
{
    /// <summary>
    /// 修改密码的参数
    /// </summary>
    [Serializable]
    public class UserInfoUpdatePasswordParam:UpdateParamBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
