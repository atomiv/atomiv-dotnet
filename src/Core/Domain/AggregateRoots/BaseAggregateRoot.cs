using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>, IAggregateRoot<TId>
    {
    }
}
