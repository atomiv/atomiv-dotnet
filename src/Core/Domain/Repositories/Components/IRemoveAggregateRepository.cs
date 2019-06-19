namespace Optivem.Core.Domain
{
    public interface IRemoveAggregateRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        void Delete(TIdentity identity);
    }
}
