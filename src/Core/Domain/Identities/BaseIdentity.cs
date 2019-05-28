using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public abstract class BaseIdentity<TId> : IIdentity<TId>
    {
        public BaseIdentity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }
    }
}
