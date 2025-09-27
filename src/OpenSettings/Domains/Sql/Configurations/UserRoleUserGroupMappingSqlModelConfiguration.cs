using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserRoleUserGroupMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserRoleUserGroupMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserRoleUserGroupMappingSqlModel> builder)
        {
            builder.ToTable("UserRoleUserGroupMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserRoleId, e.UserGroupId });

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.UserRole)
                .WithMany(e => e.UserRoleUserGroupMappings)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserGroup)
                .WithMany(e => e.UserRoleUserGroupMappings)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}