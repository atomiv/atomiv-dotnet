using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands
{
    public interface IUpdateAggregateRootMapper<TAggregateRoot, TAggregateRecord>
        where TAggregateRoot : IAggregateRoot
        where TAggregateRecord : IAggregateRecord<TAggregateRoot>
    {
        TAggregateRecord Map(TAggregateRoot aggregateRoot, TAggregateRecord record);
    }
}
