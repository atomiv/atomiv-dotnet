using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        new Task<TResponse> HandleAsync(TCommand request);
    }
}
