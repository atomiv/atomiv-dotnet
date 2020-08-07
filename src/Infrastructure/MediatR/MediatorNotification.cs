using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.MediatR
{
    public class MediatorNotification<TEvent> : INotification
    {
        public MediatorNotification(TEvent evt)
        {
            Event = evt;
        }

        public TEvent Event { get; }
    }
}
