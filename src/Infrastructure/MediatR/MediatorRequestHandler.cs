using MediatR;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.MediatR
{
    public class MediatorRequestHandler<TRequest, TResponse> : global::MediatR.IRequestHandler<MediatorRequest<TRequest, TResponse>, TResponse>
        where TRequest : Core.Common.IRequest<TResponse>
        where TResponse : IResponse
    {
        private Core.Common.IRequestHandler<TRequest, TResponse> _requestHandler;

        public MediatorRequestHandler(Core.Common.IRequestHandler<TRequest, TResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public Task<TResponse> Handle(MediatorRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
        {
            return _requestHandler.HandleAsync(request.Request);
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
            where TRequest : Core.Common.IRequest<TResponse>
            where TResponse : IResponse
        {
            // TODO: VC:
            var mediatorRequest = new MediatorRequest<TRequest, TResponse>
            {
                Request = request,
            };

            return _mediator.Send(mediatorRequest);
        }
    }
}