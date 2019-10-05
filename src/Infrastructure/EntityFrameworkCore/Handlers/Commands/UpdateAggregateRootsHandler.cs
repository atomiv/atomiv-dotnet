using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRootsHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>
        : RecordHandler<TContext, UpdateAggregateRootsRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootsResponse, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public UpdateAggregateRootsHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<UpdateAggregateRootsResponse> HandleAsync(UpdateAggregateRootsRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoots = request.AggregateRoots;

            var records = Mapper.Map<IEnumerable<TAggregateRoot>, IEnumerable<TRecord>>(aggregateRoots);

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
