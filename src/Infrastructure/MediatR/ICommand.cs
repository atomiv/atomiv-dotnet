using MediatR;

namespace Optivem.Infrastructure.MediatR
{
    public interface ICommand<TRequest, TResponse> : IRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}
