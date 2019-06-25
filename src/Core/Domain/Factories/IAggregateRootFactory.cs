namespace Optivem.Framework.Core.Domain
{
    public interface IAggregateRootFactory<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Create();
    }

    public interface IAggregateRootFactory<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        TAggregateRoot Create(TIdentity identity);
    }
}
