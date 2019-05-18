using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public TRequest Request { get; set; }
    }
}
