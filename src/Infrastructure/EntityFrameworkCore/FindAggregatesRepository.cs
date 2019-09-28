using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class FindAggregatesRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : QueryableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IFindAggregatesRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public FindAggregatesRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes) : base(context, mapper, includes)
        {
        }

        public async Task<IEnumerable<TAggregateRoot>> GetAsync()
        {
            var records = await ReadonlySet.ToListAsync();
            return Mapper.Map<IEnumerable<TRecord>, IEnumerable<TAggregateRoot>>(records);
        }
    }
}
