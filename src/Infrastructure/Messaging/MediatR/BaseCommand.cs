namespace Optivem.Infrastructure.MediatR
{
    public abstract class BaseCommand<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        public TRequest Request { get; set; }
    }
}
