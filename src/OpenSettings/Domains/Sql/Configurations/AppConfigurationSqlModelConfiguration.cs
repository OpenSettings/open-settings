using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppConfigurationSqlModelConfiguration : EntityTypeConfigurationAdapter<AppConfigurationSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppConfigurationSqlModel> builder)
        {
            builder.ToTable("AppConfigurations");

            builder.HasKey(e => e.Id);

            builder.HasIndex(a => new { a.AppId, a.IdentifierId }).IsUnique();

            builder.Property(e => e.Consumer).HasConversion(EfValueConverters.ConsumerConverter);

            builder.Property(e => e.Provider).HasConversion(EfValueConverters.ProviderConverter);

            builder.Property(e => e.Controller).HasConversion(EfValueConverters.ControllerConverter);

            builder.Property(e => e.Spa).HasConversion(EfValueConverters.SpaConverter);

            builder.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

            builder.HasOne(e => e.Tenant)
                .WithMany()
                .HasForeignKey(e => e.TenantId);

            builder.HasOne(e => e.Identifier)
                .WithMany()
                .HasForeignKey(e => e.IdentifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.App)
                .WithMany(e => e.AppConfigurations)
                .HasForeignKey(e => e.AppId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);
        }
    }
}