using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IPageAggregatesRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        IEnumerable<TAggregateRoot> Get(int page, int size);

        Task<IEnumerable<TAggregateRoot>> GetAsync(int page, int size);
    }
}
