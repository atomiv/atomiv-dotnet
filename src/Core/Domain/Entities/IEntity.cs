using System;

namespace Optivem.Framework.Core.Domain
{
    public interface IEntity : IEquatable<IEntity>
    {
    }

    public interface IEntity<TIdentity> : IEntity
        where TIdentity : IIdentity
    {
        // TODO: VC: Refactor, only getter for Id
        TIdentity Id { get; }
    }
}