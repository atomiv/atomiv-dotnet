using System;

namespace Optivem.Atomiv.Core.Common.Diagnostics
{
    public interface IRunner : IDisposable
    {
        void Run();
    }
}