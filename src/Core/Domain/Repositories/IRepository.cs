namespace Optivem.Framework.Core.Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<TAggregateRoot> : IRepository
        where TAggregateRoot : IAggregateRoot
    {
    }

    public interface IRepository<TAggregateRoot, TIdentity> : IRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}