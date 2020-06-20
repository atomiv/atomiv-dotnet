using Atomiv.Core.Application;
using Atomiv.Template.Core.Common.Requests;
using Atomiv.Template.Core.Common.Roles;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Context
{
    public class ApplicationUser : BaseApplicationUser<RequestType>
    {
        public ApplicationUser(Guid id,
            string locale, 
            string email, 
            string mobile, 
            string favoriteColor,
            IEnumerable<RoleType> roleTypes,
            IEnumerable<RequestType> actionTypes
            ) 
            : base(actionTypes)
        {
            Id = id;
            Locale = locale;
            Email = email;
            Mobile = mobile;
            FavoriteColor = favoriteColor;
            RoleTypes = roleTypes;
        }

        public Guid Id { get; }
        
        public string Locale { get; }

        public string Email { get; }

        public string Mobile { get; }

        public string FavoriteColor { get; }

        public IEnumerable<RoleType> RoleTypes { get; }
    }
}
