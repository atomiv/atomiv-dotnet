using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.Services
{
    public class BaseService : IApplicationService
    {
        public BaseService(IRequestHandler requestHandler)
        {
            RequestHandler = requestHandler;
        }

        protected IRequestHandler RequestHandler { get; private set; }

        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest
            where TResponse : IResponse
        {
            return RequestHandler.HandleAsync<TRequest, TResponse>(request);
        }
    }
}