using System;

namespace Optivem.Framework.Core.Domain
{
    public class Identity<TId> : IIdentity<TId>, IComparable<Identity<TId>>
        where TId : IEquatable<TId>, IComparable<TId>
    {
        public Identity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }

        public int CompareTo(Identity<TId> other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return Id.CompareTo(other.Id);
        }

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

            if (ReferenceEquals(Id, null) && ReferenceEquals(other.Id, null))
            {
                return true;
            }

            return Id.Equals(other.Id);
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

        public static bool operator ==(Identity<TId> a, Identity<TId> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(Identity<TId> a, Identity<TId> b)
        {
            return !Equals(a, b);
        }

        public static bool operator <(Identity<TId> a, Identity<TId> b)
        {
            return CompareTo(a, b) < 0;
        }

        public static bool operator >(Identity<TId> a, Identity<TId> b)
        {
            return CompareTo(a, b) > 0;
        }

        public static bool operator <=(Identity<TId> a, Identity<TId> b)
        {
            return CompareTo(a, b) <= 0;
        }

        public static bool operator >=(Identity<TId> a, Identity<TId> b)
        {
            return CompareTo(a, b) >= 0;
        }

        private static bool Equals(Identity<TId> a, Identity<TId> b)
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

            return a.Equals(b);
        }

        private static int CompareTo(Identity<TId> a, Identity<TId> b)
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

            return a.CompareTo(b);
        }
    }
}