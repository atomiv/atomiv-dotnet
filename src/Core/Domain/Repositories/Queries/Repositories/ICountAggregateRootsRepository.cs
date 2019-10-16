using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface ICountAggregateRootsRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<CountAggregateRootsResponse> SummarizeAsync();
    }
}