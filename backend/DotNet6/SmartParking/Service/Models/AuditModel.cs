using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Models
///  Name： AuditModel
///  Author: zy
///  Time:  2022-04-13 22:31:37
///  Version:  0.1
/// </summary>

namespace Service.Models
{
    /// <summary>
    /// 审计模型
    /// </summary>
    public class AuditModel
    {
        /// <summary>
        /// 审计ID
        /// </summary>
        public int Id { get; set; }
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
        /// <summary>
        /// 用户
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName { get; set; }
    }
}
