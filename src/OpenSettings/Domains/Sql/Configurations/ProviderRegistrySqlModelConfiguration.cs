using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class ProviderRegistrySqlModelConfiguration : EntityTypeConfigurationAdapter<ProviderRegistrySqlModel>
    {
        public override void Configure(EntityTypeBuilder<ProviderRegistrySqlModel> builder)
        {
            builder.ToTable("ProviderRegistries");

            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Type);
            builder.HasIndex(e => e.ClientIdLowercase);
            builder.HasIndex(e => e.LastHeartbeatOn);
        }
    }
}