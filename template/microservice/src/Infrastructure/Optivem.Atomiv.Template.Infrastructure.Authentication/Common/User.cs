using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

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
