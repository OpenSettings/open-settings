using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppSqlModelConfiguration : EntityTypeConfigurationAdapter<AppSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppSqlModel> builder)
        {
            builder.ToTable("Apps");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.TenantId, e.ClientId } ).IsUnique();
            builder.HasIndex(e => e.ClientNameLowercase);
            builder.HasIndex(e => new { e.TenantId, e.Slug }).IsUnique();

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.AppGroup)
                .WithMany(e => e.Apps)
                .HasForeignKey(e => e.AppGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            builder.HasMany(e => e.AppConfigurations)
                .WithOne(e => e.App)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AppSettings)
                .WithOne(e => e.App)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AppInstances)
                .WithOne(e => e.App)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AppIdentifierMappings)
                .WithOne(e => e.App)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.AppTagMappings)
                .WithOne(e => e.App)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}