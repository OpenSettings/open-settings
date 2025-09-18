using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class UserClaimMappingSqlModelConfiguration : EntityTypeConfigurationAdapter<UserClaimMappingSqlModel>
    {
        public override void Configure(EntityTypeBuilder<UserClaimMappingSqlModel> builder)
        {
            builder.ToTable("UserClaimMappings");

            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.UpdatedOn);

            builder.HasKey(e => new { e.UserId, e.UserClaimId });

            builder.HasOne(e => e.User)
                .WithMany(e => e.UserClaimMappings)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.UserClaim)
                .WithMany(e => e.UserClaimMappings)
                .HasForeignKey(e => e.UserClaimId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);
        }
    }
}