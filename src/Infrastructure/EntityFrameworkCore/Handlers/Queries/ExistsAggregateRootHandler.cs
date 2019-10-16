using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class ExistsAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>
        : RecordHandler<TContext, ExistsAggregateRootRequest<TAggregateRoot, TIdentity>, ExistsAggregateRootResponse, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public ExistsAggregateRootHandler(TContext context) : base(context)
        {
        }

        public override async Task<ExistsAggregateRootResponse> HandleAsync(ExistsAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var identity = request.Identity;
            var exists = await ReadonlyQueryable.AnyAsync(e => e.Id.Equals(identity.Id));
            return new ExistsAggregateRootResponse(exists);
        }
    }
}