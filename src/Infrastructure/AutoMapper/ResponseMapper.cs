using AutoMapper;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.AutoMapper
{


    public class ResponseMapper : IResponseMapper
    {
        public ResponseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map<T, TResponse>(T obj)
            where TResponse : IResponse
        {
            return Mapper.Map<T, TResponse>(obj);
        }

    }
    public class ResponseMapper<T, TResponse> : IResponseMapper<T, TResponse>
        where TResponse : IResponse
    {
        public ResponseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map(T obj)
        {
            return Mapper.Map<T, TResponse>(obj);
        }
    }
}