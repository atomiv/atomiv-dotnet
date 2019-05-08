namespace Optivem.Core.Application
{
    public interface IFindUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IFindRequest
        where TResponse : IFindResponse
    {
    }
}