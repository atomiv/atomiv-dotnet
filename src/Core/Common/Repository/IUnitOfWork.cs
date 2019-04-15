using System;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Common.Repository
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

        IRepository<T> GetRepository<T>() where T : class;
    }
}
