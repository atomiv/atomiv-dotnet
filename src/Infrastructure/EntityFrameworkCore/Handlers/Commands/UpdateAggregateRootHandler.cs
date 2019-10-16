using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, UpdateAggregateRootRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootResponse, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> _addAggregateRootMapper;

        public UpdateAggregateRootHandler(TContext context, IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> addAggregateRootMapper) : base(context)
        {
            _addAggregateRootMapper = addAggregateRootMapper;
        }

        public override async Task<UpdateAggregateRootResponse> HandleAsync(UpdateAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoot = request.AggregateRoot;

            var record = _addAggregateRootMapper.Create(aggregateRoot);

            try
            {
                MutableSet.Update(record);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return new UpdateAggregateRootResponse();
        }
    }
}