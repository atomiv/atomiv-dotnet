using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class Entity<TIdentity> : IEntity<TIdentity>
        where TIdentity : IIdentity
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

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var otherEntity = obj as IEntity<TIdentity>;

            if (otherEntity == null)
            {
                return false;
            }

            return Equals(otherEntity);
        }

        public bool Equals(Entity<TIdentity> other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TIdentity> first, Entity<TIdentity> second)
        {
            if (first is null)
            {
                return second is null;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TIdentity> first, Entity<TIdentity> second)
        {
            return !(first == second);
        }
    }
}