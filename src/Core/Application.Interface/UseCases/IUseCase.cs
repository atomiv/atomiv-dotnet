namespace Optivem.Core.Application
{
    public interface IUseCase<TRequest, TResponse>
        : IHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}