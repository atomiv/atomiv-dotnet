using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IUpdateAggregateRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public UpdateAggregateRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot)
        {
            var record = Mapper.Map<TAggregateRoot, TRecord>(aggregateRoot);

            try
            {
                MutableSet.Update(record);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return Mapper.Map<TRecord, TAggregateRoot>(record);
        }
    }
}
