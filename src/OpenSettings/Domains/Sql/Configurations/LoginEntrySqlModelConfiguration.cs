using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class LoginEntrySqlModelConfiguration : EntityTypeConfigurationAdapter<LoginEntrySqlModel>
    {
        public override void Configure(EntityTypeBuilder<LoginEntrySqlModel> builder)
        {
            builder.ToTable("LoginEntries");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.StateId);
            builder.HasIndex(e => new { e.StateId, e.AuthMethod, e.CreatedOn, e.IsSuccessful });
            builder.HasIndex(e => e.CreatedOn);

            builder.Property(e => e.Metadata)
                .HasConversion(EfValueConverters.ObjectDictionaryConverter).Metadata
                .SetValueComparer(EfValueComparers.ObjectDictionaryComparer);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.ProviderRegistry)
                .WithMany()
                .HasForeignKey(e => e.ProviderRegistryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}