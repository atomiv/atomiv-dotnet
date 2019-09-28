using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class FindAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : QueryableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IFindAggregateRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public FindAggregateRepository(TContext context, IMapper mapper, IEnumerable<Expression<Func<TRecord, object>>> includes) : base(context, mapper, includes)
        {
        }

        public async Task<TAggregateRoot> GetAsync(TIdentity identity)
{
            var id = identity.Id;
            
            // TODO: VC: Check equality handling and null
            var record = await ReadonlySet.SingleOrDefaultAsync(e => e.Id.Equals(identity.Id));

            if (record == null)
            {
                return null;
            }

            return Mapper.Map<TRecord, TAggregateRoot>(record);
        }
    }
}
