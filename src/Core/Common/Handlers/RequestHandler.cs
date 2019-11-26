using Optivem.Framework.Core.Common.Mapping;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common
{
    public abstract class RequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public RequestHandler(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}
