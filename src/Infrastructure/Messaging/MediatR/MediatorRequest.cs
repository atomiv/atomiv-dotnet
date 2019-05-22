using Optivem.Core.Application;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public TRequest Request { get; set; }
    }
}