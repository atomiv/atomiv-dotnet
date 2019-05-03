using AutoMapper;

namespace Optivem.Framework.Core.Application.Mappers
{
    public abstract class BaseResponseProfile<TEntity, TResponse> : Profile
    {
        public BaseResponseProfile()
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
