using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Domain
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