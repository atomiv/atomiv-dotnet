using System;

namespace Atomiv.Core.Common.Diagnostics
{
    public interface IRunner : IDisposable
    {
        void Run();
    }
}