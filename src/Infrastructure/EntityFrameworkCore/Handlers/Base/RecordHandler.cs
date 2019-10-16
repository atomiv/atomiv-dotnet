using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class RecordHandler<TContext, TRequest, TResponse, TRecord>
        : Handler<TContext, TRequest, TResponse>
        where TContext : DbContext
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
        where TRecord : class
    {
        public RecordHandler(TContext context) : base(context)
        {
            MutableSet = GetMutableSet();
            ReadonlyQueryable = GetReadonlyQueryable();
        }

        protected DbSet<TRecord> MutableSet { get; }

        protected IQueryable<TRecord> ReadonlyQueryable { get; }

        private DbSet<TRecord> GetMutableSet()
        {
            return Context.Set<TRecord>();
        }

        private IQueryable<TRecord> GetReadonlyQueryable()
        {
            return Context.Set<TRecord>().AsNoTracking();
        }

        protected IQueryable<TRecord> GetReadonlyQueryable(IEnumerable<Expression<Func<TRecord, object>>> includes)
        {
            var queryable = GetReadonlyQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include(include);
                }
            };

            return queryable;
        }
    }
}