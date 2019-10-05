using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class ListAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, ListAggregateRootsRequest<TAggregateRoot, TIdentity>, ListAggregateRootsResponse<TAggregateRoot>, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public ListAggregateRootsHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<ListAggregateRootsResponse<TAggregateRoot>> HandleAsync(ListAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var records = await ReadOnlySet.ToListAsync();
            var aggregateRoots = Mapper.Map<IEnumerable<TRecord>, IEnumerable<TAggregateRoot>>(records);
            return new ListAggregateRootsResponse<TAggregateRoot>(aggregateRoots);
        }
    }
}
