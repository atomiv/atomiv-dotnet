using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AggregateRecord<TAggregateRoot, TId> : Record<TId>, IAggregateRecord<TAggregateRoot, TId>
        where TAggregateRoot : IAggregateRoot
    {
    }
}