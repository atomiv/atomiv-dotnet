namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    // TODO: VC: Consider deleting

    /*
    public class CrudRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, ICrudRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        private AddAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _addAggregateRepository;
        private AddAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _addAggregatesRepository;
        private RemoveAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _removeAggregateRepository;
        private RemoveAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _removeAggregatesRepository;
        private UpdateAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _updateAggregateRepository;
        private UpdateAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _updateAggregatesRepository;

        public CrudRepository(TContext context, IMapper mapper, params Expression<Func<TRecord, object>>[] includes) 
            : base(context, mapper, includes)
        {
            _addAggregateRepository = new AddAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _addAggregatesRepository = new AddAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _removeAggregateRepository = new RemoveAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _removeAggregatesRepository = new RemoveAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _updateAggregateRepository = new UpdateAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _updateAggregatesRepository = new UpdateAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
        }

        public Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot)
        {
            return _addAggregateRepository.AddAsync(aggregateRoot);
        }

        public Task AddAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            return _addAggregatesRepository.AddAsync(aggregateRoots);
        }

        public Task RemoveAsync(TIdentity identity)
        {
            return _removeAggregateRepository.RemoveAsync(identity);
        }

        public Task RemoveAsync(IEnumerable<TIdentity> identities)
        {
            return _removeAggregatesRepository.RemoveAsync(identities);
        }

        public Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot)
        {
            return _updateAggregateRepository.UpdateAsync(aggregateRoot);
        }

        public Task UpdateAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            return _updateAggregatesRepository.UpdateAsync(aggregateRoots);
        }
    }
    */
}