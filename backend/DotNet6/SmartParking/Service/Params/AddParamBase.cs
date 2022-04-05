using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Params
///  Name： AddParamBase
///  Author: zy
///  Time:  2022-04-04 09:52:36
///  Version:  0.1
/// </summary>

namespace Service.Params
{
    /// <summary>
    /// 新增数据参数基础
    /// </summary>
    [Serializable]
    public class AddParamBase:ParamBase
    {
        /// <summary>
        /// 添加人
        /// </summary>
        public int? CreatedBy { get; set; }
    }
}
