using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： ParamBase
///  Author: zy
///  Time:  2022-04-03 22:35:00
///  Version:  0.1
/// </summary>

namespace Service.Params
{
    /// <summary>
    /// 参数的基类
    /// </summary>
    [Serializable]
    public class ParamBase
    {
        /// <summary>
        /// 租户编号
        /// </summary>
        public long? TenantId{get;set;}
        /// <summary>
        /// 重写ToString,返回Json
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}
