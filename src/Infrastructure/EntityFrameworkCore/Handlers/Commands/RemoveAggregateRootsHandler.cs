using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, RemoveAggregateRootsRequest<TAggregateRoot, TIdentity>, RemoveAggregateRootsResponse, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IRemoveAggregateRootMapper<TIdentity, TAggregateRecord> _removeAggregateRootMapper;

        public RemoveAggregateRootsHandler(TContext context, IRemoveAggregateRootMapper<TIdentity, TAggregateRecord> removeAggregateRootMapper) : base(context)
        {
            _removeAggregateRootMapper = removeAggregateRootMapper;
        }

        public override async Task<RemoveAggregateRootsResponse> HandleAsync(RemoveAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var identities = request.Identities;
            var records = identities.Select(e => _removeAggregateRootMapper.Map(e)).ToList();
            MutableSet.RemoveRange(records);
            await Context.SaveChangesAsync();
            return new RemoveAggregateRootsResponse();
        }
    }
}