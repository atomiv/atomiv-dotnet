using MediatR;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public interface IMediatorRequest<TResponse> : IRequest<TResponse>
    {
    }

    public interface IMediatorRequest<TRequest, TResponse> : IMediatorRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}