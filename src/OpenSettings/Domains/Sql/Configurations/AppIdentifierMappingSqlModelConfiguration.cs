using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppIdentifierMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<AppIdentifierMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppIdentifierMappingSqlModel> builder)
        {
            builder.ToTable("AppIdentifierMappings");

            builder.Ignore(e => e.Id);

            builder.HasKey(e => new { e.AppId, e.IdentifierId });

            builder.HasIndex(e => e.SortOrder);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.App)
                .WithMany(e => e.AppIdentifierMappings)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Identifier)
                .WithMany(e => e.AppIdentifierMappings)
                .HasForeignKey(e => e.IdentifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);
        }
    }
}