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
    public class PageAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, PageAggregateRootsRequest<TAggregateRoot, TIdentity>, PageAggregateRootsResponse<TAggregateRoot>, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public PageAggregateRootsHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<PageAggregateRootsResponse<TAggregateRoot>> HandleAsync(PageAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var page = request.Page;
            var size = request.Size;

            var pageIndex = page - 1;

            var skip = pageIndex * size;

            var records = await ReadOnlySet
                .Skip(skip)
                .Take(size)
                .ToListAsync();

            var totalRecords = await ReadOnlySet
                .CountAsync();

            var totalPagesDecimal = (decimal)totalRecords / size;
            var totalPages = (int) Math.Round(totalPagesDecimal, MidpointRounding.AwayFromZero);

            var aggregateRoots = Mapper.Map<IEnumerable<TRecord>, IEnumerable<TAggregateRoot>>(records);

            return new PageAggregateRootsResponse<TAggregateRoot>(aggregateRoots, totalPages, totalRecords);
        }
    }
}
