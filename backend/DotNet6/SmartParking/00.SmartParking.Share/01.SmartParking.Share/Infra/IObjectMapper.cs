using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public interface IObjectMapper
    {
        TDestination? Map<TDestination>(object source);

        TDestination? Map<TSource, TDestination>(TSource source);

        TDestination? Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
