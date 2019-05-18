using MediatR;
using Optivem.Core.Application;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.IRequest;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class MediatorRequestHandler<TRequest, TResponse> : IRequestHandler<MediatorRequest<TRequest, TResponse>, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        private IUseCase<TRequest, TResponse> _useCase;

        public MediatorRequestHandler(IUseCase<TRequest, TResponse> useCase)
        {
            _useCase = useCase;
        }

        public Task<TResponse> Handle(MediatorRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
        {
            return _useCase.HandleAsync(request.Request);
        }
    }
}
