using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserGroupMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserGroupMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserGroupMappingSqlModel> builder)
        {
            builder.ToTable("UserGroupMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserId, e.UserGroupId });

            builder.HasOne(e => e.User)
                .WithMany(e => e.UserGroupMappings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserGroup)
                .WithMany(e => e.UserGroupMappings)
                .HasForeignKey(e => e.UserGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}