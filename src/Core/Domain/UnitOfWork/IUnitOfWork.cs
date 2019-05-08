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

        IRepository<TEntity, TId> GetRepository<TEntity, TId>() where TEntity : class, IEntity<TId>;

        IReadonlyRepository<TEntity, TId> GetReadonlyRepository<TEntity, TId>() where TEntity : class, IEntity<TId>;
    }
}
