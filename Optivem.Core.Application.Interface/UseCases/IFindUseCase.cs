using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface IFindUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IFindRequest
        where TResponse : IFindResponse
    {
    }
}