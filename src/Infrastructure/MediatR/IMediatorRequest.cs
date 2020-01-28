namespace Optivem.Atomiv.Infrastructure.MediatR
{
    public interface IMediatorRequest<TResponse> : global::MediatR.IRequest<TResponse>
    {
    }

    /*
    public interface IMediatorRequest<TRequest, TResponse> : IMediatorRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
    */
}