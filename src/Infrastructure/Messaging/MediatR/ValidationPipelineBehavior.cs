using MediatR;
using Optivem.Core.Application;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.IRequest;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<MediatorRequest<TRequest, TResponse>, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        private IRequestValidationHandler<TRequest> _validationHandler;

        public ValidationPipelineBehavior(IRequestValidationHandler<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(MediatorRequest<TRequest, TResponse> request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _validationHandler.HandleAsync(request.Request);
            return await next();
        }
    }
}