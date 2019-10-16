using System;

namespace Optivem.Framework.Core.Common.Diagnostics
{
    public interface IRunner : IDisposable
    {
        void Run();
    }
}