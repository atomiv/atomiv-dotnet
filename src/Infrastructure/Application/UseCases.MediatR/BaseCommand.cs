namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public abstract class BaseCommand<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        public TRequest Request { get; set; }
    }
}
