using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.MediatR
{
    public class MediatorRequestHandler<TRequest, TResponse> : global::MediatR.IRequestHandler<MediatorRequest<TResponse>, TResponse>
        where TRequest : Core.Application.IRequest<TResponse>
    {
        private Core.Application.IRequestHandler<TRequest, TResponse> _requestHandler;

        public MediatorRequestHandler(Core.Application.IRequestHandler<TRequest, TResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public Task<TResponse> Handle(MediatorRequest<TResponse> request, CancellationToken cancellationToken)
        {
            return _requestHandler.HandleAsync((TRequest) request.Request);
        }
    }
}