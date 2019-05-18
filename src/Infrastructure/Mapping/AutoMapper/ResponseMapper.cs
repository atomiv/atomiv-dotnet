using System.Collections.Generic;
using AutoMapper;
using Optivem.Core.Application;
using Optivem.Core.Domain;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class ResponseMapper<TEntity, TResponse> : IResponseMapper<TEntity, TResponse>
        where TEntity : IEntity
        where TResponse : IResponse
    {
        public ResponseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map(TEntity entity)
        {
            return Mapper.Map<TEntity, TResponse>(entity);
        }
    }

    public class ResponseMapper : IResponseMapper
    {
        public ResponseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map<TEntity, TResponse>(TEntity entity)
            where TEntity : IEntity
            where TResponse : IResponse
        {
            return Mapper.Map<TEntity, TResponse>(entity);
        }

        public IEnumerable<TResponse> MapEnumerable<TEntity, TResponse>(IEnumerable<TEntity> entities)
            where TEntity : IEntity
            where TResponse : IResponse
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
        }
    }
}
