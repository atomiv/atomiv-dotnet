using System;

namespace Atomiv.Core.Domain
{
    public class GuidIdentity : PrimitiveIdentity<Guid>
    {
        public GuidIdentity(Guid value) : base(value)
        {
        }
    }
}
