using System.Diagnostics.CodeAnalysis;

namespace System.Linq.Expressions
{
    public static class ExpressionLogicalOperatorsExtension
    {
        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;

            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression? Visit(Expression? node)
            {
                if (node == _oldValue)
                {
                    return _newValue;
                }

                return base.Visit(node);
            }
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> firstExpr, Expression<Func<T, bool>> expr)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression expression = new ReplaceExpressionVisitor(firstExpr.Parameters[0], parameterExpression).Visit(firstExpr.Body);
            Expression expression2 = new ReplaceExpressionVisitor(expr.Parameters[0], parameterExpression).Visit(expr.Body);
            if (expression == null || expression2 == null)
            {
                return firstExpr;
            }

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expression, expression2), new ParameterExpression[1] { parameterExpression });
        }

        public static Expression<Func<T, bool>> OrIf<T>(this Expression<Func<T, bool>> firstExpr, bool condition, Expression<Func<T, bool>> expr)
        {
            if (!condition)
            {
                return firstExpr;
            }

            return firstExpr.Or(expr);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> firstExpr, Expression<Func<T, bool>> expr)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
            Expression expression = new ReplaceExpressionVisitor(firstExpr.Parameters[0], parameterExpression).Visit(firstExpr.Body);
            Expression expression2 = new ReplaceExpressionVisitor(expr.Parameters[0], parameterExpression).Visit(expr.Body);
            if (expression == null || expression2 == null)
            {
                return firstExpr;
            }

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression, expression2), new ParameterExpression[1] { parameterExpression });
        }

        public static Expression<Func<T, bool>> AndIf<T>([NotNull] this Expression<Func<T, bool>> firstExpr, bool condition, Expression<Func<T, bool>> expr)
        {
            if (!condition)
            {
                return firstExpr;
            }

            return firstExpr.And(expr);
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