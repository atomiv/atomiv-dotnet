using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class ExistsAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : QueryableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IExistsAggregateRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        public ExistsAggregateRepository(TContext context, IMapper mapper) : base(context, mapper, null)
        {
        }

        public Task<bool> ExistsAsync(TIdentity identity)
        {
            return ReadonlySet.AnyAsync(e => e.Id.Equals(identity.Id));
        }
    }
}
