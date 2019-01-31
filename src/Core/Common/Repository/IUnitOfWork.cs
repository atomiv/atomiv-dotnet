using System;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Common.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
