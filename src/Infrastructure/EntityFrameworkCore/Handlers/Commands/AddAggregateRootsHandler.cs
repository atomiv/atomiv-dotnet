using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, AddAggregateRootsRequest<TAggregateRoot, TIdentity>, AddAggregateRootsResponse<TAggregateRoot>, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public AddAggregateRootsHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<AddAggregateRootsResponse<TAggregateRoot>> HandleAsync(AddAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoots = request.AggregateRoots;
            var records = Mapper.Map<IEnumerable<TAggregateRoot>, IEnumerable<TRecord>>(aggregateRoots);
            await MutableSet.AddRangeAsync(records);
            await Context.SaveChangesAsync();
            return new AddAggregateRootsResponse<TAggregateRoot>(aggregateRoots);
        }
    }
}
