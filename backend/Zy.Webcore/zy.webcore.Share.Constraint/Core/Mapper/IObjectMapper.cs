using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Core.Mapper
{
    public interface IObjectMapper
    {
        TDestination? Map<TDestination>(object source);

        TDestination? Map<TSource, TDestination>(TSource source);

        TDestination? Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
