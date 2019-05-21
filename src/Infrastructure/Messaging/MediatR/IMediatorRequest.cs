using MediatR;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public interface IMediatorRequest<TResponse> : IRequest<TResponse>
    {
    }
}