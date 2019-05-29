using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
    }

    public interface IAggregateRoot<TIdentity> : IEntity<TIdentity>, IAggregateRoot
        where TIdentity : IIdentity
    {

    }
}
