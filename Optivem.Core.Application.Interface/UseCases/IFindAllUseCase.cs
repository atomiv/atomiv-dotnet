using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface IFindAllUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IFindAllRequest
        where TResponse : IFindAllResponse
    {
    }
}
