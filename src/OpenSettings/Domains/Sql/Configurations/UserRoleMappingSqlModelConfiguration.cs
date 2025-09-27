using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserRoleMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserRoleMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserRoleMappingSqlModel> builder)
        {
            builder.ToTable("UserRoleMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserId, e.UserRoleId });

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.User)
                .WithMany(e => e.UserRoleMappings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserRole)
                .WithMany(e => e.UserRoleMappings)
                .HasForeignKey(e => e.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}