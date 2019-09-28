using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IAddAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public AddAggregatesRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = Mapper.Map<IEnumerable<TAggregateRoot>, IEnumerable<TRecord>>(aggregateRoots);
            await MutableSet.AddRangeAsync(records);
            await Context.SaveChangesAsync();
        }
    }
}
