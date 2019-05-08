namespace Optivem.Core.Application
{
    public interface ICreateUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : ICreateRequest
        where TResponse : ICreateResponse
    {
    }
}
