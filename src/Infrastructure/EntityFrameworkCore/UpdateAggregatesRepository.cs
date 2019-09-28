using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IUpdateAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public UpdateAggregatesRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task UpdateAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = Mapper.Map<IEnumerable<TAggregateRoot>, IEnumerable<TRecord>>(aggregateRoots);

            try
            {
                MutableSet.UpdateRange(records);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }
    }
}
