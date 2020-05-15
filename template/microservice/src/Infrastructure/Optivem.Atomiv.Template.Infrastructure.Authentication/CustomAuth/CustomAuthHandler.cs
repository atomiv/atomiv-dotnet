using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Infrastructure.Authentication.CustomAuth
{
    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        private readonly IUserInfoService _userInfoService;

        private const string Bearer = "Bearer";

        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserInfoService userInfoService)
            : base(options, logger, encoder, clock)
        {
            _userInfoService = userInfoService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization))
            {
                return AuthenticateResult.Fail($"Cannot get {HeaderNames.Authorization} header value");
            }

            var bearer = authorization.FirstOrDefault();

            var token = bearer.Replace($"{Bearer} ", string.Empty);

            var userInfo = await _userInfoService.GetUserInfoAsync(token);

            var claims = userInfo.GetClaims();

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
