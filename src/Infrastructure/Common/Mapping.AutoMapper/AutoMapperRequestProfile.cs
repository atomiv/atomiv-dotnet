using AutoMapper;

namespace Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper
{
    public class AutoMapperRequestProfile<TRequest, TEntity> : Profile
    {
        protected IMappingExpression<TRequest, TEntity> map;

        public AutoMapperRequestProfile()
        {
            map = CreateMap<TRequest, TEntity>();
        }
    }
}
