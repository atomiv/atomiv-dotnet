using Optivem.Framework.Core.Common.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.System
{
    public class SystemClock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
