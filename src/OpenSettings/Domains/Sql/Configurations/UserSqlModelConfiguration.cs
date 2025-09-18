using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserSqlModelConfiguration : EntityTypeConfigurationAdapter<UserSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserSqlModel> builder)
        {
            builder.ToTable("Users");

            builder.HasIndex(e => e.Slug).IsUnique();

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasMany(e => e.UserNotificationMappings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserGroupMappings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserClaimMappings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.UserRoleMappings)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}