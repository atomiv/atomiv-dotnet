using System;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    // TODO: VC: Include getting generic repository

    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void CommitTransaction();

        void RollbackTransaction();

        // TODO: VC: Remove class constraint

        // TODO: VC: DELETE

        /*
        ICrudRepository<TAggregateRoot, TIdentity> GetRepository<TAggregateRoot, TIdentity>() 
            where TAggregateRoot : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;

        IReadonlyCrudRepository<TAggregateRoot, TIdentity> GetReadonlyRepository<TAggregateRoot, TIdentity>() 
            where TAggregateRoot : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity;

        */
    }
}