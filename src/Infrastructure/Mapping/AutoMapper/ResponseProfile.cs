using AutoMapper;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public abstract class ResponseProfile<TEntity, TResponse> : Profile
    {
        public ResponseProfile()
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