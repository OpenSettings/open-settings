using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class GlobalConfigurationSqlModelConfiguration : EntityTypeConfigurationAdapter<GlobalConfigurationSqlModel>
    {
        public override void Configure(EntityTypeBuilder<GlobalConfigurationSqlModel> builder)
        {
            builder.ToTable("GlobalConfigurations");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.Key, e.ClientId, e.IdentifierId }).IsUnique();

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            builder.HasMany(e => e.GlobalConfigurationHistories)
                .WithOne(e => e.GlobalConfiguration)
                .HasForeignKey(e => e.GlobalConfigurationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}