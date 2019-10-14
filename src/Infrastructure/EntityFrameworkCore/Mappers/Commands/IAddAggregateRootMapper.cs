using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IAddAggregateRootMapper<TAggregateRoot, TAggregateRecord>
        where TAggregateRoot : IAggregateRoot
        where TAggregateRecord : IAggregateRecord<TAggregateRoot>
    {
        TAggregateRecord Create(TAggregateRoot aggregateRoot);
    }
}
