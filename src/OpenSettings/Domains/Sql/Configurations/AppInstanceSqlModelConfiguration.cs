using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppInstanceSqlModelConfiguration : EntityTypeConfigurationAdapter<AppInstanceSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppInstanceSqlModel> builder)
        {
            builder.ToTable("AppInstances");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new { e.AppId, e.IdentifierId, e.Slug }).IsUnique();
            builder.HasIndex(e => e.NameLowercase);

            builder.Property(e => e.Urls)
                .HasConversion(EfValueConverters.ArrayStringConverter).Metadata
                .SetValueComparer(EfValueComparers.ArrayStringComparer);

            builder.Property(e => e.ReloadStrategies)
                .HasConversion(EfValueConverters.ListReloadStrategyConverter).Metadata
                .SetValueComparer(EfValueComparers.ListReloadStrategyComparer);

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.App)
                .WithMany(e => e.AppInstances)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Identifier)
                .WithMany()
                .HasForeignKey(e => e.IdentifierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}