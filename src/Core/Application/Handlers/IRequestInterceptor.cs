namespace Optivem.Framework.Core.Application
{
    public interface IRequestInterceptor<TRequest, TResponse>
        where TRequest : IRequest
    {
    }
}
