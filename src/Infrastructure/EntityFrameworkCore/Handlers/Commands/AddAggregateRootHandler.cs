using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AddAggregateRootHandler<TContext, TAggregateRoot, TIdentity, TRecord, TId> 
        : RecordHandler<TContext, AddAggregateRootRequest<TAggregateRoot, TIdentity>, AddAggregateRootResponse<TAggregateRoot>, TRecord>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IRecord<TId>
        where TId : IEquatable<TId>
    {
        public AddAggregateRootHandler(TContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<AddAggregateRootResponse<TAggregateRoot>> HandleAsync(AddAggregateRootRequest<TAggregateRoot, TIdentity> request)
        {
            var aggregateRoot = request.AggregateRoot;
            var record = Mapper.Map<TAggregateRoot, TRecord>(aggregateRoot);
            await MutableSet.AddAsync(record);
            await Context.SaveChangesAsync(); // TODO: VC: Check if correct here
            aggregateRoot = Mapper.Map<TRecord, TAggregateRoot>(record);
            return new AddAggregateRootResponse<TAggregateRoot>(aggregateRoot);
        }
    }
}
