using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IAggregateRecord : IRecord
    {
    }

    public interface IAggregateRecord<TAggregateRoot> : IAggregateRecord
            where TAggregateRoot : IAggregateRoot
    {
    }

    public interface IAggregateRecord<TAggregateRoot, TId> : IAggregateRecord<TAggregateRoot>, IRecord<TId>
        where TAggregateRoot : IAggregateRoot
    {
    }
}