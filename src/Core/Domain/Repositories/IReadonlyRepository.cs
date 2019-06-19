namespace Optivem.Core.Domain
{
    public interface IReadonlyRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>,
            IFindAggregateRepository<TAggregateRoot, TIdentity>,
            IFindAllAggregatesRepository<TAggregateRoot, TIdentity>,
            IExistAggregateRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}