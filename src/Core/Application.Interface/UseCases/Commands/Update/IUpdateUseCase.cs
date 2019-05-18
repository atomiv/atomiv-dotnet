namespace Optivem.Core.Application
{
    public interface IUpdateUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IUpdateRequest
        where TResponse : IUpdateResponse
    {
    }
}
