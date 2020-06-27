using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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

        public static string ToString(this Guid value)
        {
            return value.ToString();
        }
    }
}
