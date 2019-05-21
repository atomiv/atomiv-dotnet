namespace Optivem.Core.Application
{
    public interface IBrowseUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IBrowseRequest
        where TResponse : IBrowseResponse
    {
    }
}