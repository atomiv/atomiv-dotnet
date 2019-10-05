namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    // TODO: VC: Consider deleting

    /*
    public abstract class ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : IReadonlyRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        private readonly FindAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _findAggregateRepository;
        private readonly FindAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _findAggregatesRepository;
        private readonly PageAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _pageAggregatesRepository;
        private readonly ExistsAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> _existsAggregateRepository;


        public ReadonlyRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes)
        {
            Context = context;
            Mapper = mapper;

            _findAggregateRepository = new FindAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper, includes);
            _findAggregatesRepository = new FindAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper, includes);
            _pageAggregatesRepository = new PageAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper, includes);
            _existsAggregateRepository = new ExistsAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
        }

        protected TContext Context { get; }

        protected IMapper Mapper { get; }

        public Task<TAggregateRoot> GetAsync(TIdentity identity)
        {
            return _findAggregateRepository.GetAsync(identity);
        }

        public Task<IEnumerable<TAggregateRoot>> GetAsync()
        {
            return _findAggregatesRepository.GetAsync();
        }

        public Task<IEnumerable<TAggregateRoot>> PageAsync(int page, int size)
        {
            return _pageAggregatesRepository.PageAsync(page, size);
        }

        public Task<bool> ExistsAsync(TIdentity identity)
        {
            return _existsAggregateRepository.ExistsAsync(identity);
        }


    }
    */
}