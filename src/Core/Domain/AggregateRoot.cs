using System;

namespace Optivem.Framework.Core.Domain
{
    public class AggregateRoot<TIdentity, TId> : Entity<TIdentity, TId>, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>, IEquatable<IIdentity<TId>>, IComparable<IIdentity<TId>>
    {
        public AggregateRoot(TIdentity id)
            : base(id)
        {
        }
    }
}