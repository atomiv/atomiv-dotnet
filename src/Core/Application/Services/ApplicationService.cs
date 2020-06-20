using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public class ApplicationService : IApplicationService
    {
        public ApplicationService(IMessageBus messageBus)
        {
            MessageBus = messageBus;
        }

        protected IMessageBus MessageBus { get; private set; }

        protected Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request)
        {
            return MessageBus.SendAsync(request);
        }
    }
}