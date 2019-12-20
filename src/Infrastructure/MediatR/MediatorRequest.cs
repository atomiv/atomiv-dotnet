namespace Optivem.Framework.Infrastructure.MediatR
{
    public class MediatorRequest<TRequest, TResponse> : IMediatorRequest<TRequest, TResponse>
        where TRequest : Core.Application.IRequest<TResponse>
    {
        public TRequest Request { get; set; }
    }
}