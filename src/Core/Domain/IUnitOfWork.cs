using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
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