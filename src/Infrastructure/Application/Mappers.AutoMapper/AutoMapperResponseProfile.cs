using AutoMapper;

namespace Optivem.Framework.Infrastructure.Application.Mappers.AutoMapper
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
