using Optivem.Framework.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain.Repositories
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

        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class, IEntity<TKey>;

        IReadonlyRepository<TEntity, TKey> GetReadonlyRepository<TEntity, TKey>() where TEntity : class, IEntity<TKey>;
    }
}
