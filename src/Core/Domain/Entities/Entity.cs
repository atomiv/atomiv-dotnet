namespace Optivem.Framework.Core.Domain
{
    public class Entity<TIdentity> : IEntity<TIdentity>
        where TIdentity : IIdentity
    {
        public Entity(TIdentity id)
        {
            Id = id;
        }

        public TIdentity Id { get; }

        public override bool Equals(object obj)
        {
            return Id.Equals(obj);
        }

        public bool Equals(IEntity other)
        {
            return Id.Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}