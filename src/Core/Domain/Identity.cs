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
            return other != null && ((Id == null && other.Id == null) || Id.Equals(other.Id));
        }

        public override bool Equals(object other)
        {
            var otherIdentity = other as IIdentity<TId>;

            if(otherIdentity == null)
            {
                return false;
            }

            return Equals(otherIdentity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
