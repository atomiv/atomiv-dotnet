namespace Optivem.Core.Application
{
    public interface IFindAllUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IFindAllRequest
        where TResponse : IFindAllResponse
    {
    }
}
