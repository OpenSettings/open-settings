using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserNotificationMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserNotificationMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserNotificationMappingSqlModel> builder)
        {
            builder.ToTable("UserNotificationMappings");

            builder.Ignore(e => e.Id);

            builder.HasKey(e => new { e.UserId, e.NotificationId });

            builder.HasOne(e => e.User)
                .WithMany(e => e.UserNotificationMappings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Notification)
                .WithMany(e => e.UserNotificationMappings)
                .HasForeignKey(e => e.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}