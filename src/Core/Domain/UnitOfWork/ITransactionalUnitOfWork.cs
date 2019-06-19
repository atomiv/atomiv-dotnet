using System;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface ITransactionalUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void CommitTransaction();

        void RollbackTransaction();
    }
}