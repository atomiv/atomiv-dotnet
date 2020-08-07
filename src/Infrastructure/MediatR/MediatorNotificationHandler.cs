using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class MediatorNotificationHandler<TEvent> : global::MediatR.INotificationHandler<MediatorNotification<TEvent>>
    {
        private Core.Application.IEventHandler<TEvent> _eventHandler;

        public MediatorNotificationHandler(Core.Application.IEventHandler<TEvent> eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public Task Handle(MediatorNotification<TEvent> notification, CancellationToken cancellationToken)
        {
            return _eventHandler.HandleAsync(notification.Event);
        }
    }
}
