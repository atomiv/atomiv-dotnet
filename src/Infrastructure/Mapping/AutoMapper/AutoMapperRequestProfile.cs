using AutoMapper;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public class AutoMapperRequestProfile<TRequest, TEntity> : Profile
    {
        public AutoMapperRequestProfile()
        {
            var map = CreateMap<TRequest, TEntity>();
            Extend(map);
        }

        protected virtual void Extend(IMappingExpression<TRequest, TEntity> map)
        {
            // NOTE: No default implementation
        }
    }
}
