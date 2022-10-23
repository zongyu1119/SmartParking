using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

/// <summary>
///  Namespace: Common.Object
///  Name： ObjectExtend
///  Author: zy
///  Time:  2022-04-06 22:11:01
///  Version:  0.1
/// </summary>

namespace SmartParking.Share.ObjExt
{
    /// <summary>
    /// Object的扩展方法
    /// </summary>
    public static class ObjectExtend
    {
        /// <summary>
        /// 对象转化为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
