using Optivem.Framework.Core.Common.Time;
using System;

namespace Optivem.Framework.Infrastructure.System
{
    public class SystemClock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
