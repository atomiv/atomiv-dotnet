using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class AggregateRecord<TAggregateRoot, TId> : Record<TId>, IAggregateRecord<TAggregateRoot, TId>
        where TAggregateRoot : IAggregateRoot
    {
    }
}
