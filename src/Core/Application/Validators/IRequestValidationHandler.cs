using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidationHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}