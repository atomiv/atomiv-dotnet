using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence
{
    public static class IdentityConversion
    {
        /*

        public static Guid ToGuid(this string value)
        {
            return Guid.Parse(value);
        }

        public static Guid? TryToGuid(this string value)
        {
            var success = Guid.TryParse(value, out Guid guid);
            return success ? guid : (Guid?)null;
        }

        public static Guid ToGuid(this Identity<string> id)
        {
            return ToGuid(id.Value);
        }

        public static Guid? TryToGuid(this Identity<string> id)
        {
            return TryToGuid(id.Value);
        }

        */

        public static Guid ToGuid(this Guid value)
        {
            return value;

            // return Guid.Parse(value);
        }

        public static Guid? TryToGuid(this Guid value)
        {
            return value;

            /*
            var success = Guid.TryParse(value, out Guid guid);
            return success ? guid : (Guid?)null;
            */
        }

        public static Guid ToGuid(this Identity<Guid> id)
        {
            return ToGuid(id.Value);
        }

        public static Guid? TryToGuid(this Identity<Guid> id)
        {
            return TryToGuid(id.Value);
        }
    }
}
