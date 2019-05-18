using MediatR;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class UseCaseMediator : IUseCaseMediator
    {
        private readonly IMediator _mediator;

        public UseCaseMediator(IMediator mediator)
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

            return _mediator.Send(mediatorRequest);
        }
    }
}
