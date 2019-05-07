using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public interface ICommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
