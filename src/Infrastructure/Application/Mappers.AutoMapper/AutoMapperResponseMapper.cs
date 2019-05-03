using AutoMapper;
using Optivem.Framework.Core.Application.Ports.Mappers;

namespace Optivem.Framework.Infrastructure.Application.Mappers.AutoMapper
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
