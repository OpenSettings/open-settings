using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenSettings.Domains.Sql.Configurations.Utility;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenSettings.Domains.Sql.Configurations
{
    internal class AppSettingClassSqlModelConfiguration : EntityTypeConfigurationAdapter<AppSettingClassSqlModel>
    {
        public override void Configure(EntityTypeBuilder<AppSettingClassSqlModel> builder)
        {
            builder.ToTable("AppSettingClasses");

            builder.HasKey(e => e.Id);

#if NETSTANDARD2_0

            builder.Property(p => p.Properties)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<ICollection<PropertyInfoHelperModel>>(v, (JsonSerializerOptions)null) ?? Array.Empty<PropertyInfoHelperModel>()
                );

            builder.Property(p => p.Properties)
                .Metadata.SetValueComparer(new ValueComparer<ICollection<PropertyInfoHelperModel>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<PropertyInfoHelperModel>)c.ToArray()));

#else

            builder.Property(p => p.Properties).HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<PropertyInfoHelperModel[]>(v, (JsonSerializerOptions)null) ??
                     Array.Empty<PropertyInfoHelperModel>(),
                new ValueComparer<ICollection<PropertyInfoHelperModel>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => (ICollection<PropertyInfoHelperModel>)c.ToArray()));

#endif

            builder.HasOne(e => e.AppSetting)
                .WithOne(e => e.AppSettingClass)
                .HasForeignKey<AppSettingClassSqlModel>(e => e.AppSettingId)
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