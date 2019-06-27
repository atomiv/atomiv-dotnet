namespace Optivem.Framework.Core.Application
{
    public interface IQueryUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}
