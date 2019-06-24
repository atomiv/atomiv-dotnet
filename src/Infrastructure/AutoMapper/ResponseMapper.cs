using AutoMapper;
using Optivem.Core.Application;
using Optivem.Core.Domain;

namespace Optivem.Infrastructure.AutoMapper
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

        public TResponse Map<T, TResponse>(T obj)
            where TResponse : IResponse
        {
            return Mapper.Map<T, TResponse>(obj);
        }

    }
}