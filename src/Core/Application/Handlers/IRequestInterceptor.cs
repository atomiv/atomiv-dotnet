using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestInterceptor<TRequest, TResponse>
        where TRequest : IRequest
    {
    }
}