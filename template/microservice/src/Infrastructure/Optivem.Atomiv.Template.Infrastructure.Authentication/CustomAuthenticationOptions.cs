using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
{
    public class CustomAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; set; }
    }
}
