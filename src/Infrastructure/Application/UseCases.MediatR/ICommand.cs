using MediatR;

namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public interface ICommand<TRequest, TResponse> : IRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}
