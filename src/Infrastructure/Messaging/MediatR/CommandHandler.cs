using MediatR;
using Optivem.Core.Application;
using System.Threading;
using System.Threading.Tasks;
using IRequest = Optivem.Core.Application.IRequest;

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
