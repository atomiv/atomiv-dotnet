using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IRemoveAggregatesRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task RemoveAsync(IEnumerable<TIdentity> identities);
    }
}
