using System;

namespace Optivem.Framework.Core.Common.Time
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
