using Atomiv.Core.Domain;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence
{
    public static class IdentityConversion
    {
        public static Guid ToGuid(this string value)
        {
            return Guid.Parse(value);
        }

        public static Guid ToGuid(this Identity<string> id)
        {
            return ToGuid(id.Value);
        }
    }
}
