using System;

namespace Atomiv.Infrastructure.System
{
    public static class StringGenerator
    {
        public static string NewString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
