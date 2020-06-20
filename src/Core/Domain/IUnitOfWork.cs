using System;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();

        Task BeginAsync();

        void SaveChanges();

        Task SaveChangesAsync();

        void Commit();
    }
}