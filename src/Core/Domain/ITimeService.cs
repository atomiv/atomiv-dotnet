using System;

namespace Atomiv.Core.Domain
{
    public interface ITimeService
    {
        DateTime Now { get; }
    }
}
