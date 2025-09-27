using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserGroupNotificationMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserGroupNotificationMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserGroupNotificationMappingSqlModel> builder)
        {
            builder.ToTable("UserGroupNotificationMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { GroupId = e.UserGroupId, e.NotificationId });

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.UserGroup)
                .WithMany(e => e.UserGroupNotificationMappings)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Notification)
                .WithMany(e => e.UserGroupNotificationMappings)
                .HasForeignKey(e => e.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}