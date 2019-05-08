namespace Optivem.Core.Application
{
    public interface IDeleteUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IDeleteRequest
        where TResponse : IDeleteResponse
    {
    }
}
