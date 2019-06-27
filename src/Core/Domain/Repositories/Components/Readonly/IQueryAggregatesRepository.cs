using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IQueryAggregatesRepository<TAggregateRoot, TIdentity, TQuery>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        IEnumerable<TAggregateRoot> Get(TQuery query);

        Task<IEnumerable<TAggregateRoot>> GetAsync(TQuery query);
    }
}
