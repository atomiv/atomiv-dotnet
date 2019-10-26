using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord>
        where TAggregateRoot : IAggregateRoot
        where TAggregateRecord : IAggregateRecord<TAggregateRoot>
    {
        TAggregateRecord Map(TAggregateRoot aggregateRoot);
    }
}