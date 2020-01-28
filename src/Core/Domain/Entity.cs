using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Domain
{
    public class Entity<TIdentity> : IReadonlyEntity<TIdentity>
        where TIdentity : IComparable<TIdentity> //, IEquatable<TIdentity>
    {
        private List<Event> _events;

        public Entity(TIdentity id)
        {
            Id = id;
            _events = new List<Event>();
        }

        public TIdentity Id { get; }

        public IEnumerable<Event> GetEvents()
        {
            return _events;
        }

        protected void AddEvent(Event domainEvent)
        {
            _events.Add(domainEvent);
        }

        public bool Equals(Entity<TIdentity> other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object other)
        {
            var otherEntity = other as Entity<TIdentity>;
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

        public int CompareTo(Entity<TIdentity> other)
        {
            return CompareTo(this, other);
        }

        public static bool operator ==(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return !Equals(a, b);
        }

        public static bool operator <(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return CompareTo(a, b) < 0;
        }

        public static bool operator >(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return CompareTo(a, b) > 0;
        }

        public static bool operator <=(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return CompareTo(a, b) <= 0;
        }

        public static bool operator >=(Entity<TIdentity> a, Entity<TIdentity> b)
        {
            return CompareTo(a, b) >= 0;
        }

        private static bool Equals(Entity<TIdentity> a, Entity<TIdentity> b)
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

        private static int CompareTo(Entity<TIdentity> a, Entity<TIdentity> b)
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