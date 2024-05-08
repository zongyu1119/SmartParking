using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Extensions
{
    /// <summary>
    /// 枚举对象扩展类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获得枚举的Description
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>The description attribute.</returns>
        public static string? GetDescription(this System.Enum value)
        {
            var attr = value?.GetType()
                                     ?.GetField(value.ToString())
                                     ?.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description;
        }
    }
}
