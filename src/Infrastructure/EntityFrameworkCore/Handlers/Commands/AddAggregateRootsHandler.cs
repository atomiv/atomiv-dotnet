using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId> 
        : RecordHandler<TContext, AddAggregateRootsRequest<TAggregateRoot, TIdentity>, AddAggregateRootsResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> _addAggregateRootMapper;

        public AddAggregateRootsHandler(TContext context, IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> addAggregateRootMapper) : base(context)
        {
            _addAggregateRootMapper = addAggregateRootMapper;
        }

        public override async Task<AddAggregateRootsResponse<TAggregateRoot>> HandleAsync(AddAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoots = request.AggregateRoots;
            var records = aggregateRoots.Select(e => _addAggregateRootMapper.Create(e)).ToList();
            await MutableSet.AddRangeAsync(records);
            await Context.SaveChangesAsync();
            return new AddAggregateRootsResponse<TAggregateRoot>(aggregateRoots);
        }
    }
}
