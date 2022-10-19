using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace System.Linq
{
    public static class IQueryableConditionExtentions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> @this, bool condition, [NotNull] Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return @this;
            }

            return @this.Where(predicate);
        }

        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
        {
            if (!condition)
            {
                return @this.OrderBy((TSource e) => true);
            }

            return @this.OrderBy(keySelector, comparer);
        }

        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector)
        {
            if (!condition)
            {
                return @this.OrderByDescending((TSource e) => true);
            }

            return @this.OrderByDescending(keySelector);
        }

        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
        {
            if (!condition)
            {
                return @this.OrderByDescending((TSource e) => true);
            }

            return @this.OrderByDescending(keySelector, comparer);
        }

        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector)
        {
            if (!condition)
            {
                return @this;
            }

            return @this.ThenBy(keySelector);
        }

        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
        {
            if (!condition)
            {
                return @this;
            }

            return @this.ThenBy(keySelector, comparer);
        }

        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector, IComparer<TKey> comparer)
        {
            if (!condition)
            {
                return @this;
            }

            return @this.ThenByDescending(keySelector, comparer);
        }

        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> @this, bool condition, Expression<Func<TSource, TKey>> keySelector)
        {
            if (!condition)
            {
                return @this;
            }

            return @this.ThenByDescending(keySelector);
        }

        public static bool IsNullOrEmpty<T>(this IQueryable<T> @this)
        {
            return @this?.Any() ?? false;
        }
    }
}
