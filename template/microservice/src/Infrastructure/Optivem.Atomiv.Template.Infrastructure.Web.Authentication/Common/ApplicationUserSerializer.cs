using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Context;
using Optivem.Atomiv.Template.Core.Common.Requests;
using Optivem.Atomiv.Template.Core.Common.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.Common
{
    public class ApplicationUserSerializer : IApplicationUserSerializer<ApplicationUser, RequestType>
    {
        public ApplicationUser Deserialize(IEnumerable<Claim> claims)
        {
            var id = GetId(claims);

            var locale = claims.GetFirstOrDefault(ClaimTypes.Locality);
            var email = claims.GetFirstOrDefault(ClaimTypes.Email);
            var mobile = claims.GetFirstOrDefault(ClaimTypes.MobilePhone);
            var favoriteColor = claims.GetFirstOrDefault(CustomClaimTypes.FavoriteColor);
            var roleTypes = GetRoleTypes(claims);
            var requestTypes = GetActionTypes(claims);

            return new ApplicationUser(id, locale, email, mobile, favoriteColor, roleTypes, requestTypes);
        }

        public IEnumerable<Claim> Serialize(ApplicationUser user)
        {
            var nameIdentifier = user.Id.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Locality, user.Locale),
                new Claim(ClaimTypes.MobilePhone, user.Mobile),
            };

            foreach (var roleType in user.RoleTypes)
            {
                var roleTypeValue = roleType.ToString();
                claims.Add(new Claim(ClaimTypes.Role, roleTypeValue));
            }

            foreach (var actionType in user.RequestTypes)
            {
                var requestTypeValue = actionType.ToString();
                claims.Add(new Claim(ExtendedClaimTypes.RequestType, requestTypeValue));
            }

            return claims;
        }

        #region Helper

        private Guid GetId(IEnumerable<Claim> claims)
        {
            var value = claims.GetFirstOrDefault(ClaimTypes.NameIdentifier);

            if(value == null)
            {
                return Guid.Empty;
            }

            return Guid.Parse(value);
        }

        private IEnumerable<RoleType> GetRoleTypes(IEnumerable<Claim> claims)
        {
            var values = claims.GetAll(ClaimTypes.Role);
            return values.Select(GetRoleType);
        }

        private IEnumerable<RequestType> GetActionTypes(IEnumerable<Claim> claims)
        {
            var values = claims.GetAll(ExtendedClaimTypes.RequestType);
            return values.Select(GetRequestType);
        }

        private RoleType GetRoleType(string roleType)
        {
            return (RoleType)Enum.Parse(typeof(RoleType), roleType);
        }

        private RequestType GetRequestType(string requestType)
        {
            return (RequestType) Enum.Parse(typeof(RequestType), requestType);
        }

        #endregion
    }
}