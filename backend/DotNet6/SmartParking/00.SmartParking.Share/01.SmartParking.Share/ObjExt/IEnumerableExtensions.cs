using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.ObjExt
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> source, Action<T> action)
        {
            IEnumerable<T> source2 = source;
            Action<T> action2 = action;
            await Task.Run(() => Parallel.ForEach(source2, action2));
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Func<TSource, TKey> keySelector2 = keySelector;
            HashSet<TKey> hash = new HashSet<TKey>();
            return source.Where((TSource p) => hash.Add(keySelector2(p)));
        }

        public static void InsertAfter<T>(this IList<T> list, Func<T, bool> condition, T value)
        {
            Func<T, bool> condition2 = condition;
            foreach (var item in from p in list.Select((T item, int index) => new { item, index })
                                 where condition2(p.item)
                                 orderby p.index descending
                                 select p)
            {
                if (item.index + 1 == list.Count)
                {
                    list.Add(value);
                }
                else
                {
                    list.Insert(item.index + 1, value);
                }
            }
        }

        public static void InsertAfter<T>(this IList<T> source, int index, T value)
        {
            foreach (var item in from p in source.Select((T v, int i) => new
            {
                Value = v,
                Index = i
            })
                                 where p.Index == index
                                 orderby p.Index descending
                                 select p)
            {
                if (item.Index + 1 == source.Count)
                {
                    source.Add(value);
                }
                else
                {
                    source.Insert(item.Index + 1, value);
                }
            }
        }

        public static HashSet<TResult> ToHashSet<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            HashSet<TResult> hashSet = new HashSet<TResult>();
            hashSet.UnionWith(source.Select(selector));
            return hashSet;
        }

        public static string ToString<T>(this IEnumerable<T> source, string separator)
        {
            if (source == null || !source.Any())
            {
                return string.Empty;
            }

            return string.Join(separator, source);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source != null)
            {
                return !source.Any();
            }

            return true;
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source?.Any() ?? false;
        }
    }
}
