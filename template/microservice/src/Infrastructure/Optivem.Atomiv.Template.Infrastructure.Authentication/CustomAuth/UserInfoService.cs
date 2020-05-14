using Optivem.Atomiv.Template.Core.Common.Actions;
using Optivem.Atomiv.Template.Core.Common.Roles;
using Optivem.Atomiv.Template.Infrastructure.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public class UserInfoService : IUserInfoService
    {
        private static readonly Dictionary<string, UserInfo> Map = new Dictionary<string, UserInfo>
        {
            { "bde2080b-c50a-4ed6-a9b0-9a33ccdb1ab7", 
                new UserInfo(Guid.NewGuid(), "john.smith@acme.com", "en", "01-1234-5678", new RoleType[] { RoleType.Customer }, new ActionType[] { ActionType.CreateCustomer } ) },
            { "e3454f87-c586-411d-a36d-8575a95dc80e", 
                new UserInfo(Guid.NewGuid(), "mary.mcdonald@acme.com", "en", "02-1234-5678", new RoleType[] { RoleType.Customer }, new ActionType[] { ActionType.CreateCustomer } ) },
            { "d021c726-0f2b-498f-9850-83c0b0f89ae3", 
                new UserInfo(Guid.NewGuid(), "tom.brown@acme.com", "en", "03-1234-5678", new RoleType[] { RoleType.Customer }, new ActionType[] { ActionType.CreateCustomer } ) },
        };

        public Task<UserInfo> GetUserInfoAsync(string token)
        {
            var user = Map.ContainsKey(token) ? Map[token] : null;
            return Task.FromResult(user);
        }
    }
}
