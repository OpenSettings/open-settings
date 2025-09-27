using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class TenantSqlModelConfiguration : EntityTypeConfigurationAdapter<TenantSqlModel>
    {
        public override void Configure(EntityTypeBuilder<TenantSqlModel> builder)
        {
            builder.ToTable("Tenants");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Slug).IsUnique();

            builder.HasMany(e => e.TenantUserMappings)
                .WithOne(e => e.Tenant)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}