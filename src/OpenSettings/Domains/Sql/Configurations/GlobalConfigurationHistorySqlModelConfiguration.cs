using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class GlobalConfigurationHistorySqlModelConfiguration : EntityTypeConfigurationAdapter<GlobalConfigurationHistorySqlModel>
    {
        public override void Configure(EntityTypeBuilder<GlobalConfigurationHistorySqlModel> builder)
        {
            builder.ToTable("GlobalConfigurationHistories");

            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.KeyLowercase, e.ClientId, e.IdentifierId }).IsUnique();
            builder.HasIndex(e => e.Version);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.GlobalConfiguration)
                .WithMany(e => e.GlobalConfigurationHistories)
                .HasForeignKey(e => e.GlobalConfigurationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.RestoredBy)
                .WithMany()
                .HasForeignKey(e => e.RestoredById);
        }
    }
}