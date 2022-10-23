using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public static class AccessorExtentions
    {
        private static Func<object>? _asyncLocalAccessor;

        private static Func<object, object>? _holderAccessor;

        private static Func<object, HttpContext>? _httpContextAccessor;

        public static HttpContext? GetCurrentHttpContext(this IAccessor _)
        {
            object obj = (_asyncLocalAccessor ?? (_asyncLocalAccessor = CreateAsyncLocalAccessor()))?.Invoke();
            if (obj == null)
            {
                return null;
            }

            object obj2 = (_holderAccessor ?? (_holderAccessor = CreateHolderAccessor(obj)))?.Invoke(obj);
            if (obj2 == null)
            {
                return null;
            }

            return (_httpContextAccessor ?? (_httpContextAccessor = CreateHttpContextAccessor(obj2)))!(obj2);
            static Func<object>? CreateAsyncLocalAccessor()
            {
                FieldInfo field = typeof(HttpContextAccessor).GetField("_httpContextCurrent", BindingFlags.Static | BindingFlags.NonPublic);
                if ((object)field == null)
                {
                    return null;
                }

                return Expression.Lambda<Func<object>>(Expression.Field(null, field), Array.Empty<ParameterExpression>()).Compile();
            }

            static Func<object, object>? CreateHolderAccessor(object asyncLocal)
            {
                Type type = asyncLocal.GetType().GetGenericArguments()[0];
                MethodInfo methodInfo = typeof(AsyncLocal<>).MakeGenericType(type)?.GetProperty("Value")?.GetGetMethod();
                if ((object)methodInfo == null)
                {
                    return null;
                }

                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
                return Expression.Lambda<Func<object, object>>(Expression.Call(Expression.Convert(parameterExpression2, asyncLocal.GetType()), methodInfo), new ParameterExpression[1] { parameterExpression2 }).Compile();
            }

            static Func<object, HttpContext> CreateHttpContextAccessor(object holder)
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
                return Expression.Lambda<Func<object, HttpContext>>(Expression.Convert(Expression.Field(Expression.Convert(parameterExpression, holder.GetType()), "Context"), typeof(HttpContext)), new ParameterExpression[1] { parameterExpression }).Compile();
            }
        }
    }
}
