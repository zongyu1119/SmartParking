using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.ObjExt
{
    public static class CollectionExtension
    {
        public static void AddIf<T>([NotNull] this ICollection<T> @this, Func<T, bool> predicate, T value)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            if (predicate(value))
            {
                @this.Add(value);
            }
        }

        public static void AddIfNotContains<T>([NotNull] this ICollection<T> @this, T value)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            if (!@this.Contains(value))
            {
                @this.Add(value);
            }
        }

        public static void AddRange<T>([NotNull] this ICollection<T> @this, params T[] values)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in values)
            {
                @this.Add(item);
            }
        }

        public static void AddRangeIf<T>([NotNull] this ICollection<T> @this, Func<T, bool> predicate, params T[] values)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in values.Where(predicate))
            {
                @this.Add(item);
            }
        }

        public static void AddRangeIfNotContains<T>([NotNull] this ICollection<T> @this, params T[] values)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in values)
            {
                if (!@this.Contains(item))
                {
                    @this.Add(item);
                }
            }
        }

        public static bool ContainsAll<T>([NotNull] this ICollection<T> @this, params T[] values)
        {
            foreach (T item in values)
            {
                if (!@this.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsAny<T>([NotNull] this ICollection<T> @this, params T[] values)
        {
            foreach (T item in values)
            {
                if (@this.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> @this)
        {
            if (@this != null)
            {
                return !@this.Any();
            }

            return true;
        }

        public static bool IsNotNullOrEmpty<T>(this ICollection<T> @this)
        {
            return @this?.Any() ?? false;
        }

        public static void RemoveRange<T>([NotNull] this ICollection<T> @this, params T[] values)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in values)
            {
                @this.Remove(item);
            }
        }

        public static void RemoveRangeIf<T>([NotNull] this ICollection<T> @this, Func<T, bool> predicate, params T[] values)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in values.Where(predicate))
            {
                @this.Remove(item);
            }
        }

        public static void RemoveWhere<T>([NotNull] this ICollection<T> @this, Func<T, bool> predicate)
        {
            if (@this.IsReadOnly)
            {
                throw new InvalidOperationException("this is readonly");
            }

            foreach (T item in @this.Where(predicate).ToList())
            {
                @this.Remove(item);
            }
        }
    }
}
