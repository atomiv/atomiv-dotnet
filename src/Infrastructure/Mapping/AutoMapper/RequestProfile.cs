using AutoMapper;

namespace Optivem.Infrastructure.Mapping.AutoMapper
{
    public abstract class RequestProfile<TRequest, TEntity> : Profile
    {
        public RequestProfile()
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