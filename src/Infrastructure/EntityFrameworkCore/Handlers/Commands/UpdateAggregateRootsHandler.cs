using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, UpdateAggregateRootsRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootsResponse, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> _addAggregateRootMapper;

        public UpdateAggregateRootsHandler(TContext context, IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> addAggregateRootMapper) : base(context)
        {
            _addAggregateRootMapper = addAggregateRootMapper;
        }

        public override async Task<UpdateAggregateRootsResponse> HandleAsync(UpdateAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoots = request.AggregateRoots;

            var records = aggregateRoots.Select(e => _addAggregateRootMapper.Map(e)).ToList();

            try
            {
                MutableSet.UpdateRange(records);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return new UpdateAggregateRootsResponse();
        }
    }
}