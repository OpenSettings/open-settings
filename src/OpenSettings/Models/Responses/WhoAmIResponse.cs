using System.Collections.Generic;

namespace OpenSettings.Models.Responses
{
    public class WhoAmIResponse
    {
        /// <summary>
        /// <example>
        /// Key is the <c>ClaimType</c> and Value is <c>ClaimValue</c> e.g.
        /// <code>
        /// Key: ""
        /// Value: ""
        /// </code>
        /// </example>
        /// </summary>
        public Dictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();
    }
}