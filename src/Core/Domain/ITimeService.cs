using System;

namespace Optivem.Framework.Core.Domain
{
    public interface ITimeService
    {
        DateTime Now { get; }
    }
}
