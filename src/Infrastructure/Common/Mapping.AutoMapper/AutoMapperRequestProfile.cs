using AutoMapper;

namespace Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper
{
    public abstract class AutoMapperRequestProfile<TRequest, TEntity> : Profile
    {
        protected IMappingExpression<TRequest, TEntity> map;

        public AutoMapperRequestProfile()
        {
            map = CreateMap<TRequest, TEntity>();
        }
    }
}
