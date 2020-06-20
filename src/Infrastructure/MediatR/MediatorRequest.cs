namespace Atomiv.Infrastructure.MediatR
{
    public class MediatorRequest<TResponse> : IMediatorRequest<TResponse>
    {
        public Core.Application.IRequest<TResponse> Request { get; set; }
    }
}