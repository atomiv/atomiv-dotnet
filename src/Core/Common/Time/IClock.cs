using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.Time
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
