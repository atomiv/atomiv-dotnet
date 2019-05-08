namespace Optivem.Core.Application
{
    public interface IValidationFilter<TRequest> : IFilter<TRequest>
        where TRequest : IRequest
    {
    }
}
