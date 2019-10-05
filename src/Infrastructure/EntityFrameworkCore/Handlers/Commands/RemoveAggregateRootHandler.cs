using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, RemoveAggregateRootRequest<TAggregateRoot, TIdentity>, RemoveAggregateRootResponse, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public RemoveAggregateRootHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<RemoveAggregateRootResponse> HandleAsync(RemoveAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var identity = request.Identity;
            var record = Mapper.Map<TIdentity, TRecord>(identity);
            MutableSet.Remove(record);
            await Context.SaveChangesAsync();
            return new RemoveAggregateRootResponse();
        }
    }
}
