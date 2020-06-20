using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;
using Atomiv.Template.Core.Common.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public class ApplicationUserTokenServiceService : IApplicationUserTokenService
    {
        private static readonly Dictionary<string, ApplicationUser> Map = new Dictionary<string, ApplicationUser>
        {
            { "bde2080b-c50a-4ed6-a9b0-9a33ccdb1ab7", 
                new ApplicationUser(Guid.NewGuid(), "john.smith@acme.com", "en", "01-1234-5678", "Red", new RoleType[] { RoleType.Customer }, new RequestType[] { RequestType.CreateCustomer } ) },
            { "e3454f87-c586-411d-a36d-8575a95dc80e", 
                new ApplicationUser(Guid.NewGuid(), "mary.mcdonald@acme.com", "en", "02-1234-5678", "Blue", new RoleType[] { RoleType.Customer }, new RequestType[] { RequestType.CreateCustomer } ) },
            { "d021c726-0f2b-498f-9850-83c0b0f89ae3", 
                new ApplicationUser(Guid.NewGuid(), "tom.brown@acme.com", "en", "03-1234-5678", "Green", new RoleType[] { RoleType.Customer }, new RequestType[] { RequestType.CreateCustomer } ) },
        };

        public Task<ApplicationUser> GetApplicationUserAsync(string token)
        {
            var user = Map.ContainsKey(token) ? Map[token] : null;
            return Task.FromResult(user);
        }
    }
}
