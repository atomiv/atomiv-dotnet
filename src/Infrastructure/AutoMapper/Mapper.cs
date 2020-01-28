using Optivem.Atomiv.Core.Application.Mapping;

namespace Optivem.Atomiv.Infrastructure.AutoMapper
{
    public class Mapper : IMapper
    {
        public Mapper(global::AutoMapper.IMapper innerMapper)
        {
            InnerMapper = innerMapper;
        }

        protected global::AutoMapper.IMapper InnerMapper { get; private set; }

        public T Map<S, T>(S source)
        {
            return InnerMapper.Map<S, T>(source);
        }

        public T Map<S, T>(S source, T target)
        {
            return InnerMapper.Map<S, T>(source, target);
        }
    }
}