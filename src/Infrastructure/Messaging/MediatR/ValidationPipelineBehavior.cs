using MediatR;
using Optivem.Core.Application;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.IRequest;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest, ICommandRequest<TResponse>
        where TResponse : IResponse
    {
        private IValidationFilter<TRequest> _validationHandler;

        public ValidationPipelineBehavior(IValidationFilter<TRequest> validationHandler)
        {
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _validationHandler.HandleAsync(request);
            return await next();
        }
    }
}
