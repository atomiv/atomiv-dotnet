using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
{
    public static class CustomAuthenticationExtensions
    {
        public static AuthenticationBuilder AddCustomAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<CustomAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthenticationOptions, CustomAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
