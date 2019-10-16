using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, AddAggregateRootRequest<TAggregateRoot, TIdentity>, AddAggregateRootResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> _addAggregateRootMapper;
        private IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> _getAggregateRootMapper;

        public AddAggregateRootHandler(TContext context,
            IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord> addAggregateRootMapper,
            IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> getAggregateRootMapper) : base(context)
        {
            _addAggregateRootMapper = addAggregateRootMapper;
            _getAggregateRootMapper = getAggregateRootMapper;
        }

        public override async Task<AddAggregateRootResponse<TAggregateRoot>> HandleAsync(AddAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoot = request.AggregateRoot;
            var record = _addAggregateRootMapper.Create(aggregateRoot);
            await MutableSet.AddAsync(record);
            await Context.SaveChangesAsync(); // TODO: VC: Check if correct here
            // aggregateRoot = Mapper.Map<TRecord, TAggregateRoot>(record);
            aggregateRoot = _getAggregateRootMapper.Create(record);
            return new AddAggregateRootResponse<TAggregateRoot>(aggregateRoot);
        }
    }
}