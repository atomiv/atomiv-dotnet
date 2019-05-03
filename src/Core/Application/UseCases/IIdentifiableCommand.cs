using MediatR;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface IIdentifiableCommand<TKey, TResponse> : IRequest<TResponse>
    {
        TKey Id { get; set; }
    }
}
