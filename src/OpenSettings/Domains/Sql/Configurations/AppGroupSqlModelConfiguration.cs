using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppGroupSqlModelConfiguration : EntityTypeConfigurationAdapter<AppGroupSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppGroupSqlModel> builder)
        {
            builder.ToTable("AppGroups");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.TenantId, e.Slug }).IsUnique();
            builder.HasIndex(e => e.SortOrder);

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

            builder.HasMany(e => e.Apps)
                .WithOne(e => e.AppGroup)
                .HasForeignKey(e => e.AppGroupId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}