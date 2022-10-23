using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Params
///  Name： AuditQueryParam
///  Author: zy
///  Time:  2022-04-14 22:24:08
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.Audit
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditPageSearchDto:PageSearchDto
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// 操作的方法名
        /// </summary>
        public string? ActionNmae { set; get; }
        /// <summary>
        /// 用户
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName { get; set; }
    }
}
