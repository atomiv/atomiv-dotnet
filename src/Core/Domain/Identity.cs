namespace Optivem.Framework.Core.Domain
{
    public class Identity<TId> : IIdentity<TId>
    {
        public Identity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }

        public bool Equals(IIdentity<TId> other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // TODO: VC: Check the internals

            return (Id == null && other.Id == null) || Id.Equals(other.Id);
        }

        public override bool Equals(object other)
        {
            var otherIdentity = other as IIdentity<TId>;

            if (otherIdentity == null)
            {
                return false;
            }

            return Equals(otherIdentity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Identity<TId> first, Identity<TId> second)
        {
            if(ReferenceEquals(first, second))
            {
                return true;
            }

            if(ReferenceEquals(first, null))
            {
                return false;
            }

            if(ReferenceEquals(second, null))
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator!=(Identity<TId> first, Identity<TId> second)
        {
            return !(first == second);
        }
    }
}
