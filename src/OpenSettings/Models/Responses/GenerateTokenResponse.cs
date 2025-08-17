using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace OpenSettings.Models.Responses
{
    public class GenerateTokenResponse
    {
        public GenerateTokenResponseToken AccessToken { get; set; }

        public GenerateTokenResponseToken RefreshToken { get; set; }

        [JsonIgnore]
        public List<Claim> Claims { get; set; } = new List<Claim>(0);
    }
}