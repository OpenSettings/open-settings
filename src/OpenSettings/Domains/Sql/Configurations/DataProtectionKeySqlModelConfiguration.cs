using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class DataProtectionKeySqlModelConfiguration : EntityTypeConfigurationAdapter<DataProtectionKeySqlModel>
    {
        public override void Configure(EntityTypeBuilder<DataProtectionKeySqlModel> builder)
        {
            builder.ToTable("DataProtectionKeys");

            builder.HasKey(e => e.Id);
        }
    }
}