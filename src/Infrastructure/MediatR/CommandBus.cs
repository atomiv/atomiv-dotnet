using Atomiv.Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command)
        {
            var mediatorRequest = new MediatorRequest<TResponse>
            {
                Request = command,
            };

            return _mediator.Send(mediatorRequest);
        }
    }
}
