using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SelfServices.Api.Infrastructure.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
             IOptionsMonitor<AuthenticationSchemeOptions> options,
             ILoggerFactory logger,
             UrlEncoder encoder,
             ISystemClock clock)
             : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Request.Headers.TryGetValue("Authorization", out var authHeader);
            AuthenticationHeaderValue.TryParse(authHeader, out var authHeaderValue);
            if (string.IsNullOrEmpty(authHeaderValue?.Parameter))
                return AuthenticateResult.Fail("Authorization header not provided");

            byte[] data = Convert.FromBase64String(authHeaderValue?.Parameter);
            string credentials = Encoding.UTF8.GetString(data);
            var split = credentials.Split(':', 2);
            if (split.Count() != 2)
                return AuthenticateResult.Fail("Invalid Authorization Header");

            var clientId = split[0];
            var clientSecret = split[1];

            if (clientId != "1" || clientSecret != "2")
                return AuthenticateResult.Fail("Invalid Authorization Header");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,"tesst")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}