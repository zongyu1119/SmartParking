using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： Res
///  Author: zy
///  Time:  2022-03-31 22:55:28
///  Version:  0.1
/// </summary>

namespace Service.Comm
{
    /// <summary>
    /// 公共的返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Res<T>:ResBase
    {
        public Res(bool _success) : base(_success)
        {
        }
        public Res()
        {

        }
        /// <summary>
        /// 数据
        /// </summary>
        public T? Data { get; set; }
    }
   
}
