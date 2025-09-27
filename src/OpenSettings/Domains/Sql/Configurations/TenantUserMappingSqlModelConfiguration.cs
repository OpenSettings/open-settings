using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class TenantUserMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<TenantUserMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<TenantUserMappingSqlModel> builder)
        {
            builder.ToTable("TenantUserMappings");

            builder.Ignore(a => a.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(a => new { a.TenantId, a.UserId });

            builder.HasOne(e => e.Tenant)
                .WithMany(e => e.TenantUserMappings)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                .WithMany(e => e.TenantUserMappings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}