using System;
using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginAsync();

        Task CommitAsync();
    }
}