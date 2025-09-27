using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class LockSqlModelConfiguration : EntityTypeConfigurationAdapter<LockSqlModel>
    {
        public override void Configure(EntityTypeBuilder<LockSqlModel> builder)
        {
            builder.ToTable("Locks");

            builder.HasKey(e => e.Key);

            builder.Property(e => e.Key).HasMaxLength(100);
            builder.Property(e => e.Owner).HasMaxLength(100);

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);
        }
    }
}