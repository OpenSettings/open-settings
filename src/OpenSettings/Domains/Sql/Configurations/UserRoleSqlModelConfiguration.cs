using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserRoleSqlModelConfiguration : EntityTypeConfigurationAdapter<UserRoleSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserRoleSqlModel> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => new { a.TenantId, a.Slug }).IsUnique();

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasMany(e => e.UserRoleUserClaimMappings)
                .WithOne(e => e.UserRole)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserRoleMappings)
                .WithOne(e => e.UserRole)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserRoleUserGroupMappings)
                .WithOne(e => e.UserRole)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}