using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void CommitTransaction();

        void RollbackTransaction();

        TRepository GetRepository<TRepository>() where TRepository : IRepository;
    }
}