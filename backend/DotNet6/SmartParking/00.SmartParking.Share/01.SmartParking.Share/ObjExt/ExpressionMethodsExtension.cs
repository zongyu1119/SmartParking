using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.ObjExt
{
    public static class ExpressionMethodsExtension
    {
        public static MethodInfo GetMethod<T>(this Expression<T> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return ((expression.Body as MethodCallExpression) ?? throw new InvalidCastException("Cannot be converted to MethodCallExpression")).Method;
        }

        public static MethodCallExpression GetMethodExpression<T>(this Expression<Action<T>> method)
        {
            if (method.Body.NodeType != ExpressionType.Call)
            {
                throw new ArgumentException("Method call expected", method.Body.ToString());
            }

            return (MethodCallExpression)method.Body;
        }

        public static MethodCallExpression GetMethodExpression<T>(this Expression<Func<T, object>> exp)
        {
            switch (exp.Body.NodeType)
            {
                case ExpressionType.Call:
                    return (MethodCallExpression)exp.Body;
                case ExpressionType.Convert:
                    {
                        UnaryExpression unaryExpression = exp.Body as UnaryExpression;
                        if (unaryExpression != null)
                        {
                            MethodCallExpression methodCallExpression = unaryExpression.Operand as MethodCallExpression;
                            if (methodCallExpression != null)
                            {
                                return methodCallExpression;
                            }
                        }

                        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
                        defaultInterpolatedStringHandler.AppendLiteral("Method expected: ");
                        defaultInterpolatedStringHandler.AppendFormatted(exp.Body);
                        throw new InvalidOperationException(defaultInterpolatedStringHandler.ToStringAndClear());
                    }
                default:
                    throw new InvalidOperationException("Method expected:" + exp.Body.ToString());
            }
        }

        public static string? GetMemberName<TEntity, TMember>(this Expression<Func<TEntity, TMember>> memberExpression)
        {
            return memberExpression.GetMemberInfo()?.Name;
        }

        public static MemberInfo GetMemberInfo<TEntity, TMember>([NotNull] this Expression<Func<TEntity, TMember>> expression)
        {
            if (expression.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException("expression");
            }

            return (ExtractMemberExpression(expression.Body) ?? throw new ArgumentException("expression"))!.Member;
        }

        public static PropertyInfo? GetProperty<TEntity, TProperty>([NotNull] this Expression<Func<TEntity, TProperty>> expression)
        {
            MemberInfo memberInfo = expression.GetMemberInfo();
            if (null == memberInfo)
            {
                throw new InvalidOperationException("no property found");
            }

            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
            if ((object)propertyInfo != null)
            {
                return propertyInfo;
            }

            return typeof(TEntity).GetProperty(memberInfo.Name);
        }

        private static MemberExpression? ExtractMemberExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                return (MemberExpression)expression;
            }

            if (expression.NodeType == ExpressionType.Convert)
            {
                return ExtractMemberExpression(((UnaryExpression)expression).Operand);
            }

            return null;
        }
    }
}
