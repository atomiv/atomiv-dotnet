using MediatR;
using Atomiv.Core.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class AuthorizationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<MediatorRequest<TResponse>, TResponse>
        where TRequest : Core.Application.IRequest<TResponse>
    {
        private readonly IRequestAuthorizationHandler<TRequest> _authorizationHandler;

        public AuthorizationPipelineBehavior(IRequestAuthorizationHandler<TRequest> authorizationHandler)
        {
            _authorizationHandler = authorizationHandler;
        }

        public async Task<TResponse> Handle(MediatorRequest<TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _authorizationHandler.HandleAsync((TRequest)request.Request);
            return await next();
        }
    }
}
