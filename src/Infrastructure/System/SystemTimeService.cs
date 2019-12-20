using Optivem.Framework.Core.Domain;
using System;

namespace Optivem.Framework.Infrastructure.System
{
    public class SystemTimeService : ITimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
