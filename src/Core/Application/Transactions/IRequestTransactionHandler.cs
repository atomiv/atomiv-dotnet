using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestTransactionHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}
