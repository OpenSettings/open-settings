using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("ProviderRegistries")]
    public class ProviderRegistrySqlModel : EntityBase<int>
    {
        public ProviderRegistryScheme Scheme { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public DateTime? LastHeartbeatOn { get; set; }

        [NotMapped]
        public override DateTime? UpdatedOn { get; set; }
    }
}