using MediatR;
using Optivem.Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.MediatR
{
    public class MediatorMessageBus : IMessageBus
    {
        private readonly IMediator _mediator;

        public MediatorMessageBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> SendAsync<TResponse>(Core.Application.IRequest<TResponse> request)
        {
            // TODO: VC:
            var mediatorRequest = new MediatorRequest<TResponse>
            {
                Request = request,
            };

            return _mediator.Send(mediatorRequest);
        }
    }
}
