using Atomiv.Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MediatR
{
    public class QueryBus : IQueryBus
    {
        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query)
        {
            var mediatorRequest = new MediatorRequest<TResponse>
            {
                Request = query,
            };

            return _mediator.Send(mediatorRequest);
        }
    }
}
