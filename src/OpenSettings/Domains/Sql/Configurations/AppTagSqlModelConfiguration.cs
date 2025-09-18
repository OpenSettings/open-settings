using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppTagSqlModelConfiguration :EntityTypeConfigurationAdapter<AppTagSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppTagSqlModel> builder)
        {
            builder.ToTable("AppTags");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.NameLowercase).IsUnique();
            builder.HasIndex(e => e.Slug).IsUnique();
            builder.HasIndex(e => e.SortOrder);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            builder.HasMany(e => e.AppTagMappings)
                .WithOne(e => e.AppTag)
                .HasForeignKey(e => e.AppTagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}