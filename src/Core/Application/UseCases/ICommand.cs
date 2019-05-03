using MediatR;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface ICommand<TRequest, TResponse> : IRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}
