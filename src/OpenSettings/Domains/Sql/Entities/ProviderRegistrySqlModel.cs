using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("ProviderRegistries")]
    public class ProviderRegistrySqlModel : EntityBase<Guid>
    {
        public ProviderRegistryType Type { get; set; }

        public string ClientId { get; set; }

        public string ClientIdLowercase { get; set; }

        public ProviderRegistryScheme Scheme { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Region { get; set; }

        public DateTime LastHeartbeatOn { get; set; }

        [NotMapped]
        public override DateTime? UpdatedOn { get; set; }
    }
}