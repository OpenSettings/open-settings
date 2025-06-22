using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenSettings.Domains.Sql.Entities
{
    [Table("ProviderRegistries")]
    public class ProviderRegistrySqlModel : EntityBase<int>
    {
        public string Scheme { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public DateTime? LastHeartbeatOn { get; set; }

        [NotMapped]
        public override DateTime? UpdatedOn { get; set; }
    }

    public enum ProviderRegistryScheme
    {
        Tcp = 1,
        Grpc = 2,
        Http = 3,
        Https = 4,
        WebSocket = 5
    }
}