namespace Optivem.Framework.Core.Domain
{
    public interface IReadonlyRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>,
            IFindAggregateRepository<TAggregateRoot, TIdentity>,
            IFindAggregatesRepository<TAggregateRoot, TIdentity>,
            IPageAggregatesRepository<TAggregateRoot, TIdentity>,
            IExistsAggregateRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}