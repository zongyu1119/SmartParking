using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： Param
///  Author: zy
///  Time:  2022-04-01 22:28:16
///  Version:  0.1
/// </summary>

namespace Service.Params
{
    /// <summary>
    /// 分页查询数据的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ParamPage<T>
    {
        /// <summary>
        /// 每页个数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageCurrent { get; set; }
        public T? Param { get; set; }
    }
}
