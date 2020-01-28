using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Core.Domain
{
    public interface IReadonlyEntity<TIdentity>
    {
        public TIdentity Id { get; }
    }
}
