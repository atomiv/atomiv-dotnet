using Atomiv.Core.Application;
using Mapster;

namespace Atomiv.Infrastructure.Mapster
{
    public class Mapper : IMapper
    {
        public T Map<S, T>(S source)
        {
            return source.Adapt<T>();
        }

        public T Map<S, T>(S source, T target)
        {
            return source.Adapt(target);
        }
    }
}
