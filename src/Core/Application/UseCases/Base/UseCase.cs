using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UseCase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}