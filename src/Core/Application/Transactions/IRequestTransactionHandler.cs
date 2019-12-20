namespace Optivem.Framework.Core.Application
{
    public interface IRequestTransactionHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}