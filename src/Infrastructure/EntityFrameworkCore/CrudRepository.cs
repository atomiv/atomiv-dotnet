using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class CrudRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, ICrudRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        private AddAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _addAggregateRepository;
        private AddAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _addAggregatesRepository;
        private RemoveAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _removeAggregateRepository;
        private RemoveAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _removeAggregatesRepository;
        private UpdateAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _updateAggregateRepository;
        private UpdateAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> _updateAggregatesRepository;

        public CrudRepository(TContext context, IMapper mapper, params Expression<Func<TRecord, object>>[] includes) 
            : base(context, mapper, includes)
        {
            _addAggregateRepository = new AddAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _addAggregatesRepository = new AddAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _removeAggregateRepository = new RemoveAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _removeAggregatesRepository = new RemoveAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _updateAggregateRepository = new UpdateAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
            _updateAggregatesRepository = new UpdateAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(context, mapper);
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
}