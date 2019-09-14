using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregateRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : MutableRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, IAddAggregateRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        public AddAggregateRepository(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot)
        {
            var record = Mapper.Map<TAggregateRoot, TRecord>(aggregateRoot);
            await MutableSet.AddAsync(record);
            await Context.SaveChangesAsync(); // TODO: VC: Check if correct here
            return Mapper.Map<TRecord, TAggregateRoot>(record);
        }
    }
}
