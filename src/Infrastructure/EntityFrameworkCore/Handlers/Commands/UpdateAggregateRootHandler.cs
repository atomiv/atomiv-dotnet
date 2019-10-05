using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId>
        : RecordHandler<TContext, UpdateAggregateRootRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootResponse, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public UpdateAggregateRootHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<UpdateAggregateRootResponse> HandleAsync(UpdateAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoot = request.AggregateRoot;

            var record = Mapper.Map<TAggregateRoot, TRecord>(aggregateRoot);

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
