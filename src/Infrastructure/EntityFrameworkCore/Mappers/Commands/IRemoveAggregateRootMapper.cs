using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IRemoveAggregateRootMapper<TIdentity, TAggregateRecord>
        where TIdentity : IIdentity
        where TAggregateRecord : IAggregateRecord
    {
        TAggregateRecord Create(TIdentity identity);
    }
}
