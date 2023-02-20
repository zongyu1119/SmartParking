using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// 判断一个类不是抽象类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="publicOnly">是否只检查公共类</param>
        /// <returns></returns>
        public static bool IsNotAbstractClass(this Type type,bool publicOnly)
        {
            if (type.IsSpecialName)
                return false;

            if (type.IsClass && !type.IsAbstract)
            {
                if (type.HasAttribute<CompilerGeneratedAttribute>())
                    return false;

                if (publicOnly)
                    return type.IsPublic || type.IsNestedPublic;

                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断类是否包含某个特性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType) => type.IsDefined(attributeType, inherit: true);
        /// <summary>
        /// 判断类是否包含某个特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type) where T : Attribute => type.HasAttribute(typeof(T));
        /// <summary>
        /// 判断类是否包含某个特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type, Func<T, bool> predicate) where T : Attribute => type.GetCustomAttributes<T>(inherit: true).Any(predicate);

    }
}
