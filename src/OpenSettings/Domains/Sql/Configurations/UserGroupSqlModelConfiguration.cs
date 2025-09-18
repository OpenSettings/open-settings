using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserGroupSqlModelConfiguration : EntityTypeConfigurationAdapter<UserGroupSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserGroupSqlModel> builder)
        {
            builder.ToTable("UserGroups");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => a.Slug).IsUnique();

            builder.HasMany(e => e.UserGroupUserClaimMappings)
                .WithOne(e => e.UserGroup)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserRoleUserGroupMappings)
                .WithOne(e => e.UserGroup)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserGroupMappings)
                .WithOne(e => e.UserGroup)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserGroupNotificationMappings)
                .WithOne(e => e.UserGroup)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserGroupNotificationMappings)
                .WithOne(e => e.UserGroup)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}