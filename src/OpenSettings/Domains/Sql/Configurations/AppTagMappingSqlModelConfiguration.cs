using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppTagMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<AppTagMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppTagMappingSqlModel> builder)
        {
            builder.ToTable("AppTagMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(x => new { x.AppId, x.AppTagId });

            builder.HasOne(e => e.App)
                .WithMany(e => e.AppTagMappings)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.AppTag)
                .WithMany(e => e.AppTagMappings)
                .HasForeignKey(e => e.AppTagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}