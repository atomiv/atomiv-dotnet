using MediatR;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface IIdentifiableRequest<TResponse, TKey> : IRequest<TResponse>
    {
        TKey Id { get; set; }
    }
}
