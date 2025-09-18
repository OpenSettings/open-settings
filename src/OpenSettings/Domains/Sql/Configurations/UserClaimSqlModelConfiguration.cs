using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserClaimSqlModelConfiguration : EntityTypeConfigurationAdapter<UserClaimSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserClaimSqlModel> builder)
        {
            builder.ToTable("UserClaims");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => a.Slug).IsUnique();

            builder.HasMany(e => e.UserGroupUserClaimMappings)
                .WithOne(e => e.UserClaim)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserRoleUserClaimMappings)
                .WithOne(e => e.UserClaim)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserClaimMappings)
                .WithOne(e => e.UserClaim)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}