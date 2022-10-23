using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： AuditAddParam
///  Author: zy
///  Time:  2022-04-13 22:28:09
///  Version:  0.1
/// </summary>

namespace SmartParking.Server.Const.Dtos.Audit
{
    /// <summary>
    /// 审计新增数据模型
    /// </summary>
    public class AuditCreateDto
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
        /// 操作说明
        /// </summary>
        public string? Description { get; set; }
    }
}
