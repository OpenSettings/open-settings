using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenSettings.Domains.Sql.DataContext
{
    internal static class ModelBuilderExtensions
    {
        internal static void UseOpenSettingsModelConfiguration(this ModelBuilder modelBuilder)
        {
            var arrayConverter = new ValueConverter<string[], string>(
             v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), // string[] to serialized string
             v => JsonSerializer.Deserialize<string[]>(v, (JsonSerializerOptions)null) ?? Array.Empty<string>() // Serialized string to ICollection<string>
         );

            var arrayComparer = new ValueComparer<string[]>((c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToArray());

            var dictionaryConverter = new ValueConverter<Dictionary<string, object>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, (JsonSerializerOptions)null) ??
                     new Dictionary<string, object>()
            );

            var dictionaryComparer = new ValueComparer<Dictionary<string, object>>(
                (d1, d2) => JsonSerializer.Serialize(d1, (JsonSerializerOptions)null) == JsonSerializer.Serialize(d2, (JsonSerializerOptions)null),
                d => JsonSerializer.Serialize(d, (JsonSerializerOptions)null).GetHashCode(),
                d => new Dictionary<string, object>(d)
            );

            modelBuilder.Entity<AppSqlModel>(entity =>
            {
                entity.HasIndex(a => a.ClientId).IsUnique();
                entity.HasIndex(a => a.ClientNameLowercase).IsUnique(false);
                entity.HasIndex(a => a.Slug).IsUnique();
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
            });

            modelBuilder.Entity<SettingSqlModel>(entity =>
            {
                entity.HasIndex(a => new { a.AppId, a.IdentifierId, a.ComputedIdentifier }).IsUnique();
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

                entity.HasOne(a => a.SettingClass).WithOne(c => c.Setting)
                    .HasForeignKey<SettingClassSqlModel>(a => a.SettingId).OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.SettingHistories)
                    .WithOne(h => h.Setting)
                    .HasForeignKey(h => h.SettingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.App).WithMany(a => a.Settings);
            });

#if NETSTANDARD2_0

            modelBuilder.Entity<SettingClassSqlModel>(entity =>
            {
                entity.Property(p => p.Properties)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<ICollection<PropertyInfoHelperModel>>(v, (JsonSerializerOptions)null) ?? Array.Empty<PropertyInfoHelperModel>()
                    );

                entity.Property(p => p.Properties)
                    .Metadata.SetValueComparer(new ValueComparer<ICollection<PropertyInfoHelperModel>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (ICollection<PropertyInfoHelperModel>)c.ToArray()));
            });

#else
            modelBuilder.Entity<SettingClassSqlModel>(entity =>
            {
                entity.Property(p => p.Properties).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<PropertyInfoHelperModel[]>(v, (JsonSerializerOptions)null) ??
                         Array.Empty<PropertyInfoHelperModel>(),
                    new ValueComparer<ICollection<PropertyInfoHelperModel>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => (ICollection<PropertyInfoHelperModel>)c.ToArray()));
            });
#endif
            modelBuilder.Entity<SettingHistorySqlModel>(entity =>
            {
                entity.HasIndex(e => new { e.Slug, e.SettingId }).IsUnique();
                entity.HasIndex(e => e.Version);
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
            });

            modelBuilder.Entity<InstanceSqlModel>(entity =>
            {
                entity.HasIndex(e => new { e.AppId, e.IdentifierId, e.Slug }).IsUnique();
                entity.HasIndex(a => a.NameLowercase).IsUnique(false);

                entity.Property(e => e.Urls).HasConversion(arrayConverter).Metadata.SetValueComparer(arrayComparer);

                entity.HasOne(a => a.App).WithMany(a => a.Instances);
            });

            modelBuilder.Entity<UserSqlModel>(entity =>
            {
                entity.HasIndex(e => e.Slug).IsUnique();
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
            });

            modelBuilder.Entity<IdentifierSqlModel>(entity =>
            {
                entity.HasIndex(e => e.NameLowercase).IsUnique(false);
                entity.HasIndex(e => e.Slug).IsUnique();
                entity.HasIndex(e => e.SortOrder);
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
            });

            modelBuilder.Entity<AppGroupSqlModel>(entity =>
            {
                entity.HasIndex(e => e.NameLowercase).IsUnique();
                entity.HasIndex(e => e.Slug).IsUnique();
                entity.HasIndex(e => e.SortOrder);
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

                entity
                    .HasMany(e => e.Apps)
                    .WithOne(a => a.Group)
                    .HasForeignKey(a => a.GroupId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<TagSqlModel>(entity =>
            {
                entity.HasIndex(e => e.NameLowercase).IsUnique();
                entity.HasIndex(e => e.Slug).IsUnique();
                entity.HasIndex(e => e.SortOrder);
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
            });

            modelBuilder.Entity<AppIdentifierMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.AppId, e.IdentifierId });
                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();
                entity.HasIndex(e => e.SortOrder).IsUnique(false);

                entity
                    .HasOne(e => e.App)
                    .WithMany(e => e.AppIdentifierMappings)
                    .HasForeignKey(e => e.AppId);

                entity
                    .HasOne(e => e.Identifier)
                    .WithMany(e => e.AppIdentifierMappings)
                    .HasForeignKey(e => e.IdentifierId);
            });

            modelBuilder.Entity<AppTagMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.AppId, e.TagId });

                entity
                    .HasOne(e => e.App)
                    .WithMany(e => e.AppTagMappings)
                    .HasForeignKey(e => e.AppId);

                entity
                    .HasOne(e => e.Tag)
                    .WithMany(e => e.AppTagMappings)
                    .HasForeignKey(e => e.TagId);
            });

            modelBuilder.Entity<ConfigurationSqlModel>(entity =>
            {
                entity.HasIndex(a => new { a.AppId, a.IdentifierId }).IsUnique();

                entity.Property(e => e.RowVersion).IsRowVersion().ValueGeneratedNever();

                entity.HasOne(a => a.App).WithMany(a => a.Configurations);

                entity.Property(e => e.Consumer).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<ConfigurationConsumer>(v, (JsonSerializerOptions)null) ?? new ConfigurationConsumer()
                );

                entity.Property(e => e.Provider).HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<ConfigurationProvider>(v, (JsonSerializerOptions)null) ?? new ConfigurationProvider()
                );
            });

            modelBuilder.Entity<LockSqlModel>(entity =>
            {
                entity.HasKey(e => e.Key);
                entity.Property(e => e.Key).HasMaxLength(100);
                entity.Property(e => e.Owner).HasMaxLength(100);
            });

            modelBuilder.Entity<NotificationSqlModel>(entity =>
            {
                entity.Property(e => e.Metadata).HasConversion(dictionaryConverter).Metadata.SetValueComparer(dictionaryComparer);
            });

            modelBuilder.Entity<UserNotificationMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NotificationId });

                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.UserNotificationMappings)
                    .HasForeignKey(e => e.UserId);

                entity
                    .HasOne(e => e.Notification)
                    .WithMany(e => e.UserNotificationMappings)
                    .HasForeignKey(e => e.NotificationId);
            });

            modelBuilder.Entity<UserGroupSqlModel>(entity =>
            {
                entity.HasIndex(a => a.Slug).IsUnique();
            });

            modelBuilder.Entity<UserClaimSqlModel>(entity =>
            {
                entity.HasIndex(a => a.Slug).IsUnique();
            });

            modelBuilder.Entity<UserRoleSqlModel>(entity =>
            {
                entity.HasIndex(a => a.Slug).IsUnique();
            });

            modelBuilder.Entity<UserClaimMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClaimId });

                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.UserClaimMappings)
                    .HasForeignKey(e => e.UserId);

                entity
                    .HasOne(e => e.Claim)
                    .WithMany(e => e.UserClaimMappings)
                    .HasForeignKey(e => e.ClaimId);
            });

            modelBuilder.Entity<UserGroupClaimMappingModel>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.ClaimId });

                entity
                    .HasOne(e => e.Group)
                    .WithMany(e => e.GroupClaimMappings)
                    .HasForeignKey(e => e.GroupId);

                entity
                    .HasOne(e => e.Claim)
                    .WithMany(e => e.GroupClaimMappings)
                    .HasForeignKey(e => e.ClaimId);
            });

            modelBuilder.Entity<UserGroupMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });

                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.UserGroupMappings)
                    .HasForeignKey(e => e.UserId);

                entity
                    .HasOne(e => e.Group)
                    .WithMany(e => e.UserGroupMappings)
                    .HasForeignKey(e => e.GroupId);
            });

            modelBuilder.Entity<UserGroupNotificationMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.NotificationId });

                entity
                    .HasOne(e => e.Group)
                    .WithMany(e => e.GroupNotificationMappings)
                    .HasForeignKey(e => e.GroupId);

                entity
                    .HasOne(e => e.Notification)
                    .WithMany(e => e.UserGroupNotificationMappings)
                    .HasForeignKey(e => e.NotificationId);
            });

            modelBuilder.Entity<UserRoleClaimMappingModel>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.ClaimId });

                entity
                    .HasOne(e => e.Role)
                    .WithMany(e => e.RoleClaimMappings)
                    .HasForeignKey(e => e.RoleId);

                entity
                    .HasOne(e => e.Claim)
                    .WithMany(e => e.RoleClaimMappings)
                    .HasForeignKey(e => e.ClaimId);
            });

            modelBuilder.Entity<UserRoleGroupMappingModel>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.GroupId });

                entity
                    .HasOne(e => e.Role)
                    .WithMany(e => e.RoleGroupMappings)
                    .HasForeignKey(e => e.RoleId);

                entity
                    .HasOne(e => e.Group)
                    .WithMany(e => e.RoleGroupMappings)
                    .HasForeignKey(e => e.GroupId);
            });

            modelBuilder.Entity<UserRoleMappingSqlModel>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.UserRoleMappings)
                    .HasForeignKey(e => e.UserId);

                entity
                    .HasOne(e => e.Role)
                    .WithMany(e => e.UserRoleMappings)
                    .HasForeignKey(e => e.RoleId);
            });

            modelBuilder.Entity<LicenseSqlModel>(entity =>
            {
                entity.HasIndex(e => e.IsExpired);
                entity.HasIndex(e => e.ReferenceIdLowercase).IsUnique();
                entity.HasIndex(e => e.HolderLowercase);
                entity.HasIndex(e => e.Edition);
            });
        }

    }
}