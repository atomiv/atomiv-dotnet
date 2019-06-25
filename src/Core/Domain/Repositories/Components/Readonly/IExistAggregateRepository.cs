using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IExistAggregateRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        bool GetExists(TIdentity id);

        Task<bool> GetExistsAsync(TIdentity id);
    }
}
