using Atomiv.Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task PublishAsync<TEvent>(TEvent evt)
        {
            var mediatorNotification = new MediatorNotification<TEvent>(evt);

            return _mediator.Publish(mediatorNotification);
        }
    }
}
