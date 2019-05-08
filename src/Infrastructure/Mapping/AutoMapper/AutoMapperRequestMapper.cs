using AutoMapper;
using Optivem.Core.Application;
using Optivem.Core.Domain;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class AutoMapperRequestMapper<TRequest, TEntity> : IRequestMapper<TRequest, TEntity>
        where TRequest : IRequest
        where TEntity : IEntity
    {
        public AutoMapperRequestMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TEntity Map(TRequest request)
        {
            return Mapper.Map<TRequest, TEntity>(request);
        }
    }
}
