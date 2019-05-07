using Optivem.Core.Application.Handlers;
using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface IUseCase<TRequest, TResponse>
        : IHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {

    }
}
