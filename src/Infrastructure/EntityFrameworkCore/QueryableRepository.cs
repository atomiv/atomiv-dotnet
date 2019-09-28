using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class QueryableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : Repository<TContext>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public QueryableRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes) : base(context, mapper)
        {
            ReadonlySet = Context.Set<TRecord>().AsNoTracking();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    ReadonlySet = ReadonlySet.Include(include);
                }
            };
        }

        protected IQueryable<TRecord> ReadonlySet { get; }
    }
}
