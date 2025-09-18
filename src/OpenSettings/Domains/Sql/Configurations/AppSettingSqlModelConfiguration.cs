using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppSettingSqlModelConfiguration : EntityTypeConfigurationAdapter<AppSettingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppSettingSqlModel> builder)
        {
            builder.ToTable("AppSettings");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => new { a.AppId, a.IdentifierId, a.ComputedIdentifier }).IsUnique();

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.AppSettingClass)
                .WithOne(e => e.AppSetting)
                .HasForeignKey<AppSettingClassSqlModel>(e => e.AppSettingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Identifier)
                .WithMany()
                .HasForeignKey(e => e.IdentifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.App)
                .WithMany(e => e.AppSettings)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CopiedFrom)
                .WithMany()
                .HasForeignKey(e => e.CopiedFromId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            builder.HasMany(e => e.AppSettingHistories)
                .WithOne(e => e.AppSetting)
                .HasForeignKey(e => e.SettingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}