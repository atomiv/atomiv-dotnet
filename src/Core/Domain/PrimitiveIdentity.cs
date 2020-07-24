using System;

namespace Atomiv.Core.Domain
{
    public class PrimitiveIdentity<TValue> : Identity<TValue>
        where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        public PrimitiveIdentity(TValue value) : base(value)
        {
        }

        public static implicit operator TValue?(PrimitiveIdentity<TValue> identity)
        {
            if (identity == null)
            {
                return null;
            }

            return identity.Value;
        }

        public static implicit operator TValue(PrimitiveIdentity<TValue> identity)
        {
            if (identity == null)
            {
                throw new DomainException("Cannot cast null identity to non-nullable primitive");
            }

            return identity.Value;
        }
    }
}
