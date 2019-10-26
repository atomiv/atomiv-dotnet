using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IGetAggregateRootMapper<TAggregateRoot, TAggregateRecord>
        where TAggregateRoot : IAggregateRoot
        where TAggregateRecord : IAggregateRecord<TAggregateRoot>
    {
        TAggregateRoot Map(TAggregateRecord aggregateRecord);

        List<Expression<Func<TAggregateRecord, object>>> GetIncludes();
    }
}