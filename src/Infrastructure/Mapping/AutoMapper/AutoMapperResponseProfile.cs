using AutoMapper;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class AutoMapperResponseProfile<TEntity, TResponse> : Profile
    {
        public AutoMapperResponseProfile()
        {
            var map = CreateMap<TEntity, TResponse>();
            Extend(map);
        }

        protected virtual void Extend(IMappingExpression<TEntity, TResponse> map)
        {
            // NOTE: No default implementation
        }
    }
}
