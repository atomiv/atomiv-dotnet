using System;

namespace Optivem.Atomiv.Core.Domain
{
    public interface ITimeService
    {
        DateTime Now { get; }
    }
}
