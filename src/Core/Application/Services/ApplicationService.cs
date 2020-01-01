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

        protected Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request)
        {
            return RequestHandler.HandleAsync<TResponse>(request);
        }
    }
}