using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.ObjExt
{
    /// <summary>
    /// 反射扩展
    /// </summary>
    public static class ReflectionExtension
    {
        /// <summary>
        /// 是否不是静态类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="publicOnly"></param>
        /// <returns></returns>
        public static bool IsNotAbstractClass(this Type type, bool publicOnly)
        {
            if (type.IsSpecialName)
            {
                return false;
            }

            if (type.IsClass && !type.IsAbstract)
            {
                if (type.HasAttribute<CompilerGeneratedAttribute>())
                {
                    return false;
                }

                if (publicOnly)
                {
                    if (!type.IsPublic)
                    {
                        return type.IsNestedPublic;
                    }

                    return true;
                }

                return true;
            }

            return false;
        }
        /// <summary>
        /// 是否有某个特性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.IsDefined(attributeType, inherit: true);
        }
        /// <summary>
        /// 是否有某个特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return type.HasAttribute(typeof(T));
        }
        /// <summary>
        /// 是否有某个特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type, Func<T, bool> predicate) where T : Attribute
        {
            return type.GetCustomAttributes<T>(inherit: true).Any(predicate);
        }
    }
}
