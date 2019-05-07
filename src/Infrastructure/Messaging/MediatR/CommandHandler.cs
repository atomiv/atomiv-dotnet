using MediatR;
using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.Requests.IRequest;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest, ICommandRequest<TResponse>
        where TResponse : IResponse
    {
        private IUseCase<TRequest, TResponse> _useCase;

        public CommandHandler(IUseCase<TRequest, TResponse> useCase)
        {
            _useCase = useCase;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return _useCase.HandleAsync(request);
        }
    }
}
