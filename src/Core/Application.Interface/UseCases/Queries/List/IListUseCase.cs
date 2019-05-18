namespace Optivem.Core.Application
{
    public interface IListUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IListRequest
        where TResponse : IListResponse
    {
    }
}
