using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IRemoveAggregateRootMapper<TIdentity, TAggregateRecord>
        where TIdentity : IIdentity
        where TAggregateRecord : IAggregateRecord
    {
        TAggregateRecord Create(TIdentity identity);
    }
}