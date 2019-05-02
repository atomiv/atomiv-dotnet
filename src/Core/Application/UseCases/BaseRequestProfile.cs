using AutoMapper;

namespace Optivem.Framework.Core.Application.UseCases
{
    public abstract class BaseRequestProfile<TRequest, TEntity> : Profile
    {
        public BaseRequestProfile()
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
