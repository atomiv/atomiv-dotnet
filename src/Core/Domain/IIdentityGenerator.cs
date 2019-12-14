using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Domain
{
    public interface IIdentityGenerator<TIdentity>
    {
        TIdentity Next();
    }
}
