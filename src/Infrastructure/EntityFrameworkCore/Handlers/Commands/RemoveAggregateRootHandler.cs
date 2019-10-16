using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class RemoveAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, RemoveAggregateRootRequest<TAggregateRoot, TIdentity>, RemoveAggregateRootResponse, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IRemoveAggregateRootMapper<TIdentity, TAggregateRecord> _removeAggregateRootMapper;

        public RemoveAggregateRootHandler(TContext context, IRemoveAggregateRootMapper<TIdentity, TAggregateRecord> removeAggregateRootMapper) : base(context)
        {
            _removeAggregateRootMapper = removeAggregateRootMapper;
        }

        public override async Task<RemoveAggregateRootResponse> HandleAsync(RemoveAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var identity = request.Identity;
            var record = _removeAggregateRootMapper.Create(identity);
            MutableSet.Remove(record);
            await Context.SaveChangesAsync();
            return new RemoveAggregateRootResponse();
        }
    }
}