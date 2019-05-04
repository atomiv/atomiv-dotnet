using AutoMapper;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.AutoMapper
{
    public class AutoMapperResponseMapper<TEntity, TResponse> : IResponseMapper<TEntity, TResponse>
    {
        public AutoMapperResponseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map(TEntity entity)
        {
            return Mapper.Map<TEntity, TResponse>(entity);
        }
    }
}
