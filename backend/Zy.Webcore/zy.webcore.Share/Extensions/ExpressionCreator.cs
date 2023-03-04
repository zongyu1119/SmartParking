﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Extensions
{
    public static class ExpressionCreator
    {
        public static Expression<Func<T, bool>> New<T>(Expression<Func<T, bool>>? expr = null)
          => expr ?? (x => true);

        public static Expression<Func<T1, T2, bool>> New<T1, T2>(Expression<Func<T1, T2, bool>>? expr = null)
            => expr ?? ((x, y) => true);

        public static Expression<Func<T1, T2, T3, bool>> New<T1, T2, T3>(Expression<Func<T1, T2, T3, bool>>? expr = null)
            => expr ?? ((x, y, z) => true);
    }
}
