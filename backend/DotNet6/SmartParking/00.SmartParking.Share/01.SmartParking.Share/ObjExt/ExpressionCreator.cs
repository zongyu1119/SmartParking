using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq.Expressions
{
    public static class ExpressionCreator
    {
        public static Expression<Func<T, bool>> New<T>(Expression<Func<T, bool>>? expr = null)
        {
            return expr ?? ((T x) => true);
        }

        public static Expression<Func<T1, T2, bool>> New<T1, T2>(Expression<Func<T1, T2, bool>>? expr = null)
        {
            return expr ?? ((T1 x, T2 y) => true);
        }

        public static Expression<Func<T1, T2, T3, bool>> New<T1, T2, T3>(Expression<Func<T1, T2, T3, bool>>? expr = null)
        {
            return expr ?? ((T1 x, T2 y, T3 z) => true);
        }
    }
}
