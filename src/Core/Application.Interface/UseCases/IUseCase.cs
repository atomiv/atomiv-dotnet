namespace Optivem.Core.Application
{
    public interface IUseCase<TRequest, TResponse>
        : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}