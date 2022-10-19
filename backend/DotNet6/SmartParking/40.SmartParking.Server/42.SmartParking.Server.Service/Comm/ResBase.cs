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
        /// 使用是否成功初始化
        /// </summary>
        /// <param name="_success"></param>
        public ResBase(bool _success)
        {
            Success = _success;
            if (Success)
            {
                Code =ResCodeType.Success;
            }
        }
        public ResBase()
        {

        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// 代码
        /// </summary>
        public ResCodeType Code { get; set; } = ResCodeType.Fail;
        /// <summary>
        /// 消息
        /// </summary>
        public string? Message { get; set; } = "";
    }
    /// <summary>
    /// 返回消息代码类型
    /// </summary>
    public enum ResCodeType
    {
        /// <summary>
        /// 成功0
        /// </summary>
        Success = 0,
        /// <summary>
        /// 失败1
        /// </summary>
        Fail = 1,
    }
}
