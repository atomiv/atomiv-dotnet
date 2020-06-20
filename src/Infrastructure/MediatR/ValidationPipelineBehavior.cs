using MediatR;
using Atomiv.Core.Application;
using System.Threading;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<MediatorRequest<TResponse>, TResponse>
        where TRequest : Core.Application.IRequest<TResponse>
    {
        private IRequestValidationHandler<TRequest> _validationHandler;

        public ValidationPipelineBehavior(IRequestValidationHandler<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(MediatorRequest<TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _validationHandler.HandleAsync((TRequest) request.Request);
            return await next();
        }
    }
}