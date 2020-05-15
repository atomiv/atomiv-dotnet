using Optivem.Atomiv.Infrastructure.AspNetCore;
using System;
using System.Security.Claims;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.Common
{
    public class User : BaseUser
    {
        public User(ClaimsPrincipal principal) : base(principal)
        {
        }

        public Guid Id
        {
            get
            {
                var value = GetFirst(ClaimTypes.NameIdentifier);
                return Guid.Parse(value);
            }
        }
        
        public string Locale => GetFirstOrDefault(ClaimTypes.Locality);

        public string Email => GetFirstOrDefault(ClaimTypes.Email);

        public string Mobile => GetFirstOrDefault(ClaimTypes.MobilePhone);

        public string FavoriteColor => GetFirstOrDefault(CustomClaimTypes.FavoriteColor);
    }
}
