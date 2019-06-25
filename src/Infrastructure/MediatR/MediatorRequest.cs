using Optivem.Framework.Core.Application;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public TRequest Request { get; set; }
    }
}