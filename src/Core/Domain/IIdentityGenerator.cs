using System;

namespace Atomiv.Core.Domain
{
    [Obsolete("Use IGenerator instead of IIdentityGenerator")]
    public interface IIdentityGenerator<TIdentity> : IGenerator<TIdentity>
    {
    }
}
