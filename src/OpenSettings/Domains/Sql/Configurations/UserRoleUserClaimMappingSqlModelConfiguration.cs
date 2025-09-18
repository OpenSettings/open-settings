using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserRoleUserClaimMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserRoleUserClaimMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserRoleUserClaimMappingSqlModel> builder)
        {
            builder.ToTable("UserRoleUserClaimMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserRoleId, e.UserClaimId });

            builder.HasOne(e => e.UserRole)
                .WithMany(e => e.UserRoleUserClaimMappings)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserClaim)
                .WithMany(e => e.UserRoleUserClaimMappings)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}