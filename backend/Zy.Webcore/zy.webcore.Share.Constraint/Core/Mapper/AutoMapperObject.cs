using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Core.Mapper
{
    public class AutoMapperObject : IObjectMapper
    {
        private readonly IMapper _mapper;

        public AutoMapperObject(IMapper mapper) => _mapper = mapper;

        public TDestination? Map<TDestination>(object source)
        {
            if (source is null)
                return default;
            return _mapper.Map<TDestination>(source);
        }

        public TDestination? Map<TSource, TDestination>(TSource source)
        {
            if (source is null)
                return default;
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination? Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source is null)
                return default;
            return _mapper.Map(source, destination);
        }
    }
}
