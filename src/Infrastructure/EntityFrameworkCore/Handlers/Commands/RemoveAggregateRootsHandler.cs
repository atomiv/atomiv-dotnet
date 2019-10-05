using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>
        : RecordHandler<TContext, RemoveAggregateRootsRequest<TAggregateRoot, TIdentity>, RemoveAggregateRootsResponse, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public RemoveAggregateRootsHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<RemoveAggregateRootsResponse> HandleAsync(RemoveAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var identities = request.Identities;
            var records = Mapper.Map<IEnumerable<TIdentity>, IEnumerable<TRecord>>(identities);
            MutableSet.RemoveRange(records);
            await Context.SaveChangesAsync();
            return new RemoveAggregateRootsResponse();
        }
    }
}
