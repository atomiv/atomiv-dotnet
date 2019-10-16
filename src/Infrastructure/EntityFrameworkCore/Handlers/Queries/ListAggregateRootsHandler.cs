using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class ListAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, ListAggregateRootsRequest<TAggregateRoot, TIdentity>, ListAggregateRootsResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> _getAggregateRootMapper;

        public ListAggregateRootsHandler(TContext context, IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> getAggregateRootMapper) : base(context)
        {
            _getAggregateRootMapper = getAggregateRootMapper;
        }

        public override async Task<ListAggregateRootsResponse<TAggregateRoot>> HandleAsync(ListAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var records = await ReadonlyQueryable.ToListAsync();
            var aggregateRoots = records.Select(e => _getAggregateRootMapper.Create(e)).ToList();
            return new ListAggregateRootsResponse<TAggregateRoot>(aggregateRoots);
        }
    }
}