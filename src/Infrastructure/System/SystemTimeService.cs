using Atomiv.Core.Domain;
using System;

namespace Atomiv.Infrastructure.System
{
    public class SystemTimeService : ITimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
