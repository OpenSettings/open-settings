using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class IdentifierSqlModelConfiguration : EntityTypeConfigurationAdapter<IdentifierSqlModel>
    {
        public override void Configure(EntityTypeBuilder<IdentifierSqlModel> builder)
        {
            builder.ToTable("Identifiers");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.NameLowercase);
            builder.HasIndex(e => e.Slug).IsUnique();
            builder.HasIndex(e => e.SortOrder);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            builder.HasMany(e => e.AppIdentifierMappings)
                .WithOne(e => e.Identifier)
                .HasForeignKey(e => e.IdentifierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}