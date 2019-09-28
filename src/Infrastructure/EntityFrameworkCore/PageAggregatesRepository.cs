using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class PageAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : QueryableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IPageAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public PageAggregatesRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes) : base(context, mapper, includes)
        {
        }

        public async Task<IEnumerable<TAggregateRoot>> PageAsync(int page, int size)
        {
            var pageIndex = page - 1;

            var skip = pageIndex * size;

            var records = await ReadonlySet
                .Skip(skip)
                .Take(size)
                .ToListAsync();

            return Mapper.Map<IEnumerable<TRecord>, IEnumerable<TAggregateRoot>>(records);
        }
    }
}
