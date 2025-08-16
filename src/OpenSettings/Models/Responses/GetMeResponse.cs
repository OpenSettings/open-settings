using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class GetMeResponse
    {
        public bool IsAuthenticated { get; set; }

        public string AccessToken { get; set; }

        /// <summary>
        /// <example>
        /// Key is the <c>ClaimType</c> and Value is <c>ClaimValue</c> e.g.
        /// <code>
        /// Key: "db_user_displayName"
        /// Value: "Alice Smith"
        /// </code>
        /// </example>
        /// </summary>
        public Dictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();
    }
}