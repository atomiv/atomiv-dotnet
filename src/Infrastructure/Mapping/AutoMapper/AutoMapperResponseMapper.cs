using AutoMapper;
using Optivem.Core.Application;
using Optivem.Core.Application.Mappers;
using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class AutoMapperResponseMapper<TEntity, TResponse> : IResponseMapper<TEntity, TResponse>
        where TEntity : IEntity
        where TResponse : IResponse
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
