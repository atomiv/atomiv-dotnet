using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Domain.Entities
{
    public interface IEntity<TId>
    {
        // TODO: VC: Refactor, only getter for Id
        TId Id { get; set; }
    }
}
