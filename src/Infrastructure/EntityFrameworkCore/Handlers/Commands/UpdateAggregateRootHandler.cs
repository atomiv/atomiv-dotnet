using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class UpdateAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, UpdateAggregateRootRequest<TAggregateRoot, TIdentity>, UpdateAggregateRootResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private readonly IUpdateAggregateRootMapper<TAggregateRoot, TAggregateRecord> _updateAggregateRootMapper;
        private readonly IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> _getAggregateRootMapper;

        public UpdateAggregateRootHandler(TContext context, 
            IUpdateAggregateRootMapper<TAggregateRoot, TAggregateRecord> updateAggregateRootMapper,
            IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> getAggregateRootMapper) : base(context)
        {
            _updateAggregateRootMapper = updateAggregateRootMapper;
            _getAggregateRootMapper = getAggregateRootMapper;
        }

        public override async Task<UpdateAggregateRootResponse<TAggregateRoot>> HandleAsync(UpdateAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoot = request.AggregateRoot;
            var recordId = aggregateRoot.Id.Id;

            var includes = _getAggregateRootMapper.GetIncludes();

            var record = await GetMutableQueryable(includes).FirstAsync(e => e.Id.Equals(recordId));

            _updateAggregateRootMapper.Map(aggregateRoot, record);

            try
            {
                MutableSet.Update(record);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            aggregateRoot = _getAggregateRootMapper.Map(record);

            return new UpdateAggregateRootResponse<TAggregateRoot>(aggregateRoot);
        }
    }
}