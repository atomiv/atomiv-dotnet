using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        private readonly IUserInfoService _userInfoService;

        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserInfoService userInfoService)
            : base(options, logger, encoder, clock)
        {
            _userInfoService = userInfoService;
        }

        // TODO: VC: Continue from https://github.com/ignas-sakalauskas/CustomAuthenticationNetCore/blob/master/CustomAuthNetCore21/Authentication/CustomAuthHandler.cs

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // TODO: VC: Enable later

            /*
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return Task.FromResult(AuthenticateResult.Fail($"Cannot get {HeaderNames.Authorization} header value"));
            }

            // authorization[0]

            */

            var token = "bde2080b-c50a-4ed6-a9b0-9a33ccdb1ab7"; // TODO: VC: Get from header

            var userInfo = await _userInfoService.GetUserInfoAsync(token);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "My name"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ExtendedClaimTypes.ActionType, "CreateCustomerCommand"),
            };

            var identity = new ClaimsIdentity(claims); // TODO: VC: Username and password

            var principal = new ClaimsPrincipal(identity); // TODO: VC: Check other constructors
            var properties = new AuthenticationProperties();
            var scheme = Scheme.Name;

            var ticket = new AuthenticationTicket(principal, properties, scheme);

            var result = AuthenticateResult.Success(ticket);

            return result;
        }
    }
}
