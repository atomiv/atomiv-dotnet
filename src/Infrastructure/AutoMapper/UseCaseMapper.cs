
using AutoMapper;
using Optivem.Framework.Core.Application.Mappers;

namespace Optivem.Framework.Infrastructure.AutoMapper
{
    public class UseCaseMapper : IUseCaseMapper
    {
        public UseCaseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

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
