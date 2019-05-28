using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IIdentity
    {

    }

    public interface IIdentity<TId> : IIdentity
    {
        TId Id { get; }
    }
}
