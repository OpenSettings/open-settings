using System;
using System.Collections.Generic;

namespace Ogu.Vehicle.IdentityServer.WebApp.Models
{
    public class TranslationDto
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string DefaultValue { get; set; }

        public IEnumerable<CultureValueMappingDto> CultureValueMappings { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
    }
}