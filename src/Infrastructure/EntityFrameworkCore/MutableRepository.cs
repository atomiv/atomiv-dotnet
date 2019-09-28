using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : Repository<TContext>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public MutableRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
            MutableSet = context.Set<TRecord>();
        }

        protected DbSet<TRecord> MutableSet { get; }
    }
}
