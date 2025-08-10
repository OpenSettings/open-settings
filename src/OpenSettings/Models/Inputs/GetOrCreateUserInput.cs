using System.Security.Claims;

namespace OpenSettings.Models.Inputs
{
    public class GetOrCreateUserInput
    {
        public GetOrCreateUserInput(ClaimsPrincipal principal, AuthType authType)
        {
            Principal = principal;
            AuthType = authType;
        }

        public ClaimsPrincipal Principal { get; }

        public AuthType AuthType { get; }
    }
}