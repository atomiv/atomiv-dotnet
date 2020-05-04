using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {

        }

        // TODO: VC: Continue from https://github.com/ignas-sakalauskas/CustomAuthenticationNetCore/blob/master/CustomAuthNetCore21/Authentication/CustomAuthHandler.cs

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // TODO: VC: Enable later

            /*
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail($"Cannot get {HeaderNames.Authorization} header value"));
            }

            // authorization[0]

            */

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "My name"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var identity = new ClaimsIdentity(claims); // TODO: VC: Username and password

            var principal = new ClaimsPrincipal(identity); // TODO: VC: Check other constructors
            var properties = new AuthenticationProperties();
            var scheme = Scheme.Name;

            var ticket = new AuthenticationTicket(principal, properties, scheme);

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
