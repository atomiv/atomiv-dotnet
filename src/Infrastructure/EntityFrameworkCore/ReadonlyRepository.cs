using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : IReadonlyRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        private readonly FindAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _findAggregateRepository;
        private readonly FindAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _findAggregatesRepository;
        private readonly ExistsAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _existsAggregateRepository;

        public ReadonlyRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes)
        {
            Context = context;
            Mapper = mapper;

            _findAggregateRepository = new FindAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper, includes);
            _findAggregatesRepository = new FindAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper, includes);
            _existsAggregateRepository = new ExistsAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
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

        public Task<bool> ExistsAsync(TIdentity identity)
        {
            return _existsAggregateRepository.ExistsAsync(identity);
        }
    }
}