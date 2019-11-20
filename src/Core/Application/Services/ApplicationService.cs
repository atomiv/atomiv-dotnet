using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class ApplicationService : IApplicationService
    {
        public ApplicationService(IRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        protected IRequestHandler RequestHandler { get; private set; }

        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return RequestHandler.HandleAsync<TRequest, TResponse>(request);
        }
    }
}