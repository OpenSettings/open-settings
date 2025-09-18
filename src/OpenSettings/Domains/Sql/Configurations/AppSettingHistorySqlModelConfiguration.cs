using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppSettingHistorySqlModelConfiguration : EntityTypeConfigurationAdapter<AppSettingHistorySqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppSettingHistorySqlModel> builder)
        {
            builder.ToTable("AppSettingHistories");

            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.Slug, e.SettingId }).IsUnique();
            builder.HasIndex(e => e.Version);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.AppSetting)
                .WithMany(e => e.AppSettingHistories)
                .HasForeignKey(e => e.SettingId)
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