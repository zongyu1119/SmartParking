using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： ResBase
///  Author: zy
///  Time:  2022-03-31 22:58:14
///  Version:  0.1
/// </summary>

namespace Service.Comm
{
    /// <summary>
    /// 返回值基础
    /// </summary>
    public class ResBase
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; } = "200";
        /// <summary>
        /// 消息
        /// </summary>
        public string? Message { get; set; }
    }
}
