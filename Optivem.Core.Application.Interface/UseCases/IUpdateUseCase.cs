using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface IUpdateUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IUpdateRequest
        where TResponse : IUpdateResponse
    {
    }
}
