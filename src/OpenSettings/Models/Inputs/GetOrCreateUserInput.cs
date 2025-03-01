using System.Security.Claims;

namespace OpenSettings.Models.Inputs
{
    public class GetOrCreateUserInput
    {
        public GetOrCreateUserInput(ClaimsPrincipal principal, string authScheme)
        {
            Principal = principal;
            AuthScheme = authScheme;
        }

        public ClaimsPrincipal Principal { get; }

        public string AuthScheme { get; }
    }
}