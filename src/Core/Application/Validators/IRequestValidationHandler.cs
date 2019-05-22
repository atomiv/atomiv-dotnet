namespace Optivem.Core.Application
{
    public interface IRequestValidationHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}