using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IRemoveAggregateRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        public RemoveAggregateRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task RemoveAsync(TIdentity identity)
        {
            var record = Mapper.Map<TIdentity, TRecord>(identity);
            MutableSet.Remove(record);
            await Context.SaveChangesAsync();
        }
    }
}
