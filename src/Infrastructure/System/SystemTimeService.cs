using Optivem.Atomiv.Core.Domain;
using System;

namespace Optivem.Atomiv.Infrastructure.System
{
    public class SystemTimeService : ITimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
