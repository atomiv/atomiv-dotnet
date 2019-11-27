using System;

namespace Optivem.Framework.Core.Domain
{
    public class Identity<TId> : IEquatable<Identity<TId>>, IComparable<Identity<TId>> 
        where TId : IEquatable<TId>, IComparable<TId>
    {
        public Identity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }

        public bool Equals(Identity<TId> other)
        {
            return Equals(this, other);
        }

        public override bool Equals(object other)
        {
            var otherIdentity = other as Identity<TId>;
            return Equals(otherIdentity);
        }

        public override int GetHashCode()
        {
            if(ReferenceEquals(Id, null))
            {
                return 0;
            }

            return Id.GetHashCode();
        }

        public int CompareTo(Identity<TId> other)
        {
            return CompareTo(this, other);
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

            if (a.GetType() != b.GetType())
            {
                return false;
            }

            if (ReferenceEquals(a.Id, b.Id))
            {
                return true;
            }

            if(ReferenceEquals(a.Id, null))
            {
                return false;
            }

            if(ReferenceEquals(b.Id, null))
            {
                return false;
            }

            return a.Id.Equals(b.Id);
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

            if(ReferenceEquals(a.Id, b.Id))
            {
                return 0;
            }

            if(ReferenceEquals(a.Id, null))
            {
                return -1;
            }

            if(ReferenceEquals(b.Id, null))
            {
                return 1;
            }

            return a.Id.CompareTo(b.Id);
        }
    }
}