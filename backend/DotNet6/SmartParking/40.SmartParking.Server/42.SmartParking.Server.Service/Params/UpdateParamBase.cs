using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Params
///  Name： UpdateParamBase
///  Author: zy
///  Time:  2022-04-04 09:52:55
///  Version:  0.1
/// </summary>

namespace Service.Params
{
    /// <summary>
    /// 修改数据参数的基类
    /// </summary>
    [Serializable]
    public class UpdateParamBase:ParamBase
    {
        /// <summary>
        /// 修改人
        /// </summary>
        public int? UpdatedBy { get; set; }
    }
}
