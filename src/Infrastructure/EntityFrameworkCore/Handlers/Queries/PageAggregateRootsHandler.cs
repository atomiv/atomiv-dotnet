using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class PageAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId> 
        : RecordHandler<TContext, PageAggregateRootsRequest<TAggregateRoot, TIdentity>, PageAggregateRootsResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> _getAggregateRootMapper;

        public PageAggregateRootsHandler(TContext context, IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> getAggregateRootMapper) : base(context)
        {
            _getAggregateRootMapper = getAggregateRootMapper;
        }

        public override async Task<PageAggregateRootsResponse<TAggregateRoot>> HandleAsync(PageAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var page = request.Page;
            var size = request.Size;

            var pageIndex = page - 1;

            var skip = pageIndex * size;

            var records = await ReadonlyQueryable
                .Skip(skip)
                .Take(size)
                .ToListAsync();

            var totalRecords = await ReadonlyQueryable
                .CountAsync();

            var totalPagesDecimal = (decimal)totalRecords / size;
            var totalPages = (int) Math.Round(totalPagesDecimal, MidpointRounding.AwayFromZero);

            var aggregateRoots = records.Select(e => _getAggregateRootMapper.Create(e)).ToList();

            return new PageAggregateRootsResponse<TAggregateRoot>(aggregateRoots, totalPages, totalRecords);
        }
    }
}
