using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Domain
{
    public interface IEvent
    {
    }

    public interface IEvent<TId>
    {
        TId Id { get; set; }
    }
}
