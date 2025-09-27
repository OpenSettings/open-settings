using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserGroupUserClaimMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserGroupUserClaimMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserGroupUserClaimMappingSqlModel> builder)
        {
            builder.ToTable("UserGroupUserClaimMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserGroupId, e.UserClaimId });

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.UserGroup)
                .WithMany(e => e.UserGroupUserClaimMappings)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserClaim)
                .WithMany(e => e.UserGroupUserClaimMappings)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}