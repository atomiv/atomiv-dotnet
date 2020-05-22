using Optivem.Atomiv.Infrastructure.AspNetCore;
using Optivem.Atomiv.Template.Core.Common.Actions;
using Optivem.Atomiv.Template.Core.Common.Roles;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class UserInfo
    {
        public UserInfo(Guid id, 
            string email, 
            string locale, 
            string mobile,
            IEnumerable<RoleType> roles,
            IEnumerable<RequestType> actions)
        {
            Id = id;
            Email = email;
            Locale = locale;
            Mobile = mobile;
            Roles = roles;
            Actions = actions;
        }

        public Guid Id { get; }

        public string Email { get; }

        public string Locale { get; }

        public string Mobile { get; }

        public IEnumerable<RoleType> Roles { get; }

        public IEnumerable<RequestType> Actions { get; }

        public IEnumerable<Claim> GetClaims()
        {
            var nameIdentifier = Id.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Locality, Locale),
                new Claim(ClaimTypes.MobilePhone, Mobile),
            };

            foreach(var role in Roles)
            {
                var roleValue = role.ToString();
                claims.Add(new Claim(ClaimTypes.Role, roleValue));
            }

            foreach(var action in Actions)
            {
                var actionValue = action.ToString();
                claims.Add(new Claim(ExtendedClaimTypes.ActionType, actionValue));
            }

            return claims;
        }
    }
}
