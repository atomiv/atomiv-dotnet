using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IAggregateRootFactory<TAggregateRoot, TRecord>
        where TAggregateRoot : IAggregateRoot
        where TRecord : IRecord
    {
        TAggregateRoot Create(TRecord record);
    }
}
