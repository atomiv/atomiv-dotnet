using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Web.Authentication.CustomAuth
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        private readonly IApplicationUserTokenService _applicationUserTokenService;
        private readonly IApplicationUserSerializer<ApplicationUser, RequestType> _applicationUserSerializer;

        private const string Bearer = "Bearer";

        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock, 
            IApplicationUserTokenService applicationUserTokenService,
            IApplicationUserSerializer<ApplicationUser, RequestType> applicationUserSerializer)
            : base(options, logger, encoder, clock)
        {
            _applicationUserTokenService = applicationUserTokenService;
            _applicationUserSerializer = applicationUserSerializer;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return AuthenticateResult.Fail($"Cannot get {HeaderNames.Authorization} header value");
            }

            var bearer = authorization.FirstOrDefault();

            var token = bearer.Replace($"{Bearer} ", string.Empty);

            var applicationUser = await _applicationUserTokenService.GetApplicationUserAsync(token);

            var claims = _applicationUserSerializer.Serialize(applicationUser);

            var identity = new ClaimsIdentity(claims); // TODO: VC: Check other constructirs

            var principal = new ClaimsPrincipal(identity); // TODO: VC: Check other constructors
            var properties = new AuthenticationProperties();
            var scheme = Scheme.Name;

            var ticket = new AuthenticationTicket(principal, properties, scheme);

            var result = AuthenticateResult.Success(ticket);

            return result;
        }
    }
}
