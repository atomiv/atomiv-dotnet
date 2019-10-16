using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public interface IAggregateRootRequest<TResponse, TAggregateRoot, TIdentity> : IRequest<TResponse>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}