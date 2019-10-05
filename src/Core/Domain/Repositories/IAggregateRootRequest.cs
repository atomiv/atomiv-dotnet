using Optivem.Framework.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Domain
{
    public interface IAggregateRootRequest<TAggregateRoot, TIdentity> : IRequest
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}
