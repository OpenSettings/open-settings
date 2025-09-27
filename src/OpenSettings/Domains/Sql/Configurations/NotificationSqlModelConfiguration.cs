using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class NotificationSqlModelConfiguration : EntityTypeConfigurationAdapter<NotificationSqlModel>
    {
        public override void Configure(EntityTypeBuilder<NotificationSqlModel> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Metadata)
                .HasConversion(EfValueConverters.ObjectDictionaryConverter).Metadata
                .SetValueComparer(EfValueComparers.ObjectDictionaryComparer);

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);


            builder.HasMany(e => e.UserNotificationMappings)
                .WithOne(e => e.Notification)
                .HasForeignKey(e => e.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserGroupNotificationMappings)
                .WithOne(e => e.Notification)
                .HasForeignKey(e => e.NotificationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}