using System.Collections.Generic;

namespace Ogu.Vehicle.IdentityServer.WebApp.Models
{
    public class PostRequestClientClaimDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public IEnumerable<CultureValueMappingDto> CultureValueMappings { get; set; }
    }
}