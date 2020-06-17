using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Optivem.Atomiv.Core.Application
{
    public static class ClaimsExtensions
    {
        public static string GetFirstOrDefault(this IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims
                .FirstOrDefault(e => e.Type == claimType);

            return claim?.Value;
        }

        public static string GetFirst(this IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims
                .First(e => e.Type == claimType);

            return claim.Value;
        }

        public static string GetSingleOrDefault(this IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims
                .SingleOrDefault(e => e.Type == claimType);

            return claim?.Value;
        }

        public static string GetSingle(this IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims
                .Single(e => e.Type == claimType);

            return claim.Value;
        }

        public static IEnumerable<string> GetAll(this IEnumerable<Claim> claims, string claimType)
        {
            return claims
                .Where(e => e.Type == claimType)
                .Select(e => e.Value)
                .ToList();
        }

        public static bool Any(this IEnumerable<Claim> claims, string claimType)
        {
            return claims
                .Any(e => e.Type == claimType);
        }

        public static bool Any(this IEnumerable<Claim> claims, string claimType, string claimValue)
        {
            return claims
                .Any(e => e.Type == claimType
                    && e.Value == claimValue);
        }
    }
}
