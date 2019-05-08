using MediatR;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public interface ICommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
