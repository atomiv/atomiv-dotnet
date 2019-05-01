using AutoMapper;
using Optivem.Framework.Core.Common.Mapping;
using System;

namespace Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper
{
    public class AutoMapperMappingService : IMappingService
    {
        protected readonly IMapper mapper;

        public AutoMapperMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return mapper.Map(source, sourceType, destinationType);
        }
    }
}
