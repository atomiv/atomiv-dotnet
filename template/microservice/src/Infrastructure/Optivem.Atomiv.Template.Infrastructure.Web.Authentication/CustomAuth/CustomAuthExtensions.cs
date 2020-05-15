using Microsoft.AspNetCore.Authentication;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddCustomAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>(authenticationScheme, displayName, configureOptions);
        }

        public static AuthenticationBuilder AddCustomAuthentication(this AuthenticationBuilder builder, string authenticationScheme, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>(authenticationScheme, configureOptions);
        }

        public static AuthenticationBuilder AddCustomAuthentication(this AuthenticationBuilder builder, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>(CustomAuthDefaults.AuthenticationScheme, configureOptions);
        }
    }
}
