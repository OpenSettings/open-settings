using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class LicenseSqlModelConfiguration : EntityTypeConfigurationAdapter<LicenseSqlModel>
    {
        public override void Configure(EntityTypeBuilder<LicenseSqlModel> builder)
        {
            builder.ToTable("Licenses");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.IsExpired);
            builder.HasIndex(e => e.ReferenceIdLowercase).IsUnique();
            builder.HasIndex(e => e.HolderLowercase);
            builder.HasIndex(e => e.Edition);

            builder.Property(e => e.Features)
                .HasConversion(EfValueConverters.ArrayStringConverter).Metadata
                .SetValueComparer(EfValueComparers.ArrayStringComparer);

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);
        }
    }
}