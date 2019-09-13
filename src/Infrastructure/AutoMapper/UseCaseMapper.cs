using Optivem.Framework.Core.Common.Mapping;

namespace Optivem.Framework.Infrastructure.AutoMapper
{
    public class UseCaseMapper : IMapper
    {
        public UseCaseMapper(global::AutoMapper.IMapper mapper)
        {
            Mapper = mapper;
        }

        protected global::AutoMapper.IMapper Mapper { get; private set; }

        public T Map<S, T>(S source)
        {
            return Mapper.Map<S, T>(source);
        }

        public T Map<S, T>(S source, T target)
        {
            return Mapper.Map<S, T>(source, target);
        }
    }
}
