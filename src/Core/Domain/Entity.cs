using System;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class Entity<TIdentity, TId> : IEntity<TIdentity>
        where TIdentity : IIdentity<TId>, IEquatable<IIdentity<TId>>, IComparable<IIdentity<TId>>
    {
        private List<IEvent> _events;

        public Entity(TIdentity id)
        {
            Id = id;
            _events = new List<IEvent>();
        }

        public TIdentity Id { get; }

        public IEnumerable<IEvent> GetEvents()
        {
            return _events;
        }

        protected void AddEvent(IEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public bool Equals(IEntity<TIdentity> other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object other)
        {
            var otherEntity = other as IEntity<TIdentity>;
            return Equals(otherEntity);
        }

        public override int GetHashCode()
        {
            if (ReferenceEquals(Id, null))
            {
                return 0;
            }

            return Id.GetHashCode();
        }

        public int CompareTo(IEntity<TIdentity> other)
        {
            return CompareTo(this, other);
        }

        public static bool operator ==(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return !Equals(a, b);
        }

        public static bool operator <(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return CompareTo(a, b) < 0;
        }

        public static bool operator >(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return CompareTo(a, b) > 0;
        }

        public static bool operator <=(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return CompareTo(a, b) <= 0;
        }

        public static bool operator >=(Entity<TIdentity, TId> a, Entity<TIdentity, TId> b)
        {
            return CompareTo(a, b) >= 0;
        }

        private static bool Equals(IEntity<TIdentity> a, IEntity<TIdentity> b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null))
            {
                return false;
            }

            if (ReferenceEquals(b, null))
            {
                return false;
            }

            if (a.GetType() != b.GetType())
            {
                return false;
            }

            if (ReferenceEquals(a.Id, b.Id))
            {
                return true;
            }

            if (ReferenceEquals(a.Id, null))
            {
                return false;
            }

            if (ReferenceEquals(b.Id, null))
            {
                return false;
            }

            return a.Id.Equals(b.Id);
        }

        private static int CompareTo(IEntity<TIdentity> a, IEntity<TIdentity> b)
        {
            if (ReferenceEquals(a, b))
            {
                return 0;
            }

            if (ReferenceEquals(a, null))
            {
                return -1;
            }

            if (ReferenceEquals(b, null))
            {
                return 1;
            }

            if (ReferenceEquals(a.Id, b.Id))
            {
                return 0;
            }

            if (ReferenceEquals(a.Id, null))
            {
                return -1;
            }

            if (ReferenceEquals(b.Id, null))
            {
                return 1;
            }

            return a.Id.CompareTo(b.Id);
        }
    }
}