using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IRemoveAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public RemoveAggregatesRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task RemoveAsync(IEnumerable<TIdentity> identities)
        {
            var records = Mapper.Map<IEnumerable<TIdentity>, IEnumerable<TRecord>>(identities);
            MutableSet.RemoveRange(records);
            await Context.SaveChangesAsync();
        }
    }
}
