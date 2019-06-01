using MediatR;
using Optivem.Core.Application;
using System;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.IRequest;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class MediatorRequestHandler<TRequest, TResponse> : global::MediatR.IRequestHandler<MediatorRequest<TRequest, TResponse>, TResponse>
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
            try
            {
                return _useCase.HandleAsync(request.Request);
            }
            catch(Exception ex)
            {
                throw new RequestHandlerException($"Error handling use case {typeof(IUseCase<TRequest, TResponse>)}", ex);
            }
        }
    }
    public class MediatorRequestHandler : IRequestHandler
    {
        private readonly IMediator _mediator;

        public MediatorRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Core.Application.IRequest
            where TResponse : IResponse
        {
            // TODO: VC:
            var mediatorRequest = new MediatorRequest<TRequest, TResponse>
            {
                Request = request,
            };

            try
            {
                return _mediator.Send(mediatorRequest);
            }
            catch (Exception ex)
            {
                throw new RequestHandlerException($"Error handling use case {typeof(IUseCase<TRequest, TResponse>)}", ex);
            }
        }
    }
}