using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;

namespace Optivem.Core.Application.UseCases
{
    public interface IDeleteUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IDeleteRequest
        where TResponse : IDeleteResponse
    {
    }
}
