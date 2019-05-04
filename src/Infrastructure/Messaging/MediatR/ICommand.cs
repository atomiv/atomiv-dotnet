using MediatR;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public interface ICommand<TRequest, TResponse> : IRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}
