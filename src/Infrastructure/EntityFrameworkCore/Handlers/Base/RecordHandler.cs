using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class RecordHandler<TContext, TRequest, TResponse, TRecord>
        : Handler<TContext, TRequest, TResponse>
        where TContext : DbContext
        where TRequest : IRequest
        where TResponse : IResponse
        where TRecord : class
    {
        public RecordHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
            QueryIncludes = mapper.Map<TRecord, IEnumerable<Expression<Func<TRecord, object>>>>(null);
            MutableSet = GetMutableSet();
            ReadOnlySet = GetReadOnlySet();
        }

        protected DbSet<TRecord> MutableSet { get; }

        protected IQueryable<TRecord> ReadOnlySet { get; }

        protected IEnumerable<Expression<Func<TRecord, object>>> QueryIncludes { get; }

        private DbSet<TRecord> GetMutableSet()
        {
            return Context.Set<TRecord>();
        }

        private IQueryable<TRecord> GetReadOnlySet()
        {
            var queryable = Context.Set<TRecord>().AsNoTracking();

            if (QueryIncludes != null)
            {
                foreach (var include in QueryIncludes)
                {
                    queryable = queryable.Include(include);
                }
            };

            return queryable;
        }
    }
}
