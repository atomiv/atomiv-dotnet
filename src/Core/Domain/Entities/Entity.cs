using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    // TODO: VC: Handling undefined / unset identity, in that case should not be equal

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
            if (obj == null)
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
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TIdentity> first, Entity<TIdentity> second)
        {
            if (first == null)
            {
                return second == null;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TIdentity> first, Entity<TIdentity> second)
        {
            return !(first == second);
        }
    }
}