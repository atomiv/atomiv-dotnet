using AutoMapper;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class AutoMapperRequestMapper<TRequest, TEntity> : IRequestMapper<TRequest, TEntity>
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
