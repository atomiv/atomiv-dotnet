using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class FindAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, FindAggregateRootRequest<TAggregateRoot, TIdentity>, FindAggregateRootResponse<TAggregateRoot>, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {

        private IAggregateRootFactory<TAggregateRoot, TRecord> _aggregateRootFactory;

        public FindAggregateRootHandler(TContext context, IMapper mapper, IAggregateRootFactory<TAggregateRoot, TRecord> aggregateRootFactory) : base(context, mapper)
        {
            _aggregateRootFactory = aggregateRootFactory;
        }

        public override async Task<FindAggregateRootResponse<TAggregateRoot>> HandleAsync(FindAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var identity = request.Identity;

            if (identity == null)
            {
                return null;
            }

            var id = identity.Id;

            // TODO: VC: Check equality handling and null
            var record = await ReadOnlySet.SingleOrDefaultAsync(e => e.Id.Equals(identity.Id));

            if (record == null)
            {
                return new FindAggregateRootResponse<TAggregateRoot>(null);
            }

            // var aggregateRoot = Mapper.Map<TRecord, TAggregateRoot>(record);
            var aggregateRoot = _aggregateRootFactory.Create(record);

            return new FindAggregateRootResponse<TAggregateRoot>(aggregateRoot);
        }
    }
}
