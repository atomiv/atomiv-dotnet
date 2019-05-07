using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface ICreateUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : ICreateRequest
        where TResponse : ICreateResponse
    {
    }
}
