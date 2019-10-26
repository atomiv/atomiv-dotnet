using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class FindAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TAggregateRecord, TId>
        : RecordHandler<TContext, FindAggregateRootRequest<TAggregateRoot, TIdentity>, FindAggregateRootResponse<TAggregateRoot>, TAggregateRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TAggregateRecord : class, IAggregateRecord<TAggregateRoot, TId>
        where TId : IEquatable<TId>
    {
        private IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> _getAggregateRootMapper;

        public FindAggregateRootHandler(TContext context, IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord> getAggregateRootMapper) : base(context)
        {
            _getAggregateRootMapper = getAggregateRootMapper;
        }

        public override async Task<FindAggregateRootResponse<TAggregateRoot>> HandleAsync(FindAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var identity = request.Identity;

            if (identity == null)
            {
                return null;
            }

            var id = identity.Id;

            var includes = _getAggregateRootMapper.GetIncludes();

            var readonlyQueryable = GetReadonlyQueryable(includes);

            var recordId = identity.Id;

            // TODO: VC: Check equality handling and null
            var record = await readonlyQueryable
                .SingleOrDefaultAsync(e => e.Id.Equals(recordId));

            if (record == null)
            {
                return new FindAggregateRootResponse<TAggregateRoot>(null);
            }

            // var aggregateRoot = Mapper.Map<TRecord, TAggregateRoot>(record);
            var aggregateRoot = _getAggregateRootMapper.Map(record);

            return new FindAggregateRootResponse<TAggregateRoot>(aggregateRoot);
        }
    }
}