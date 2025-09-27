using Microsoft.EntityFrameworkCore;
using OpenSettings.Domains.Sql.Configurations;
using OpenSettings.Domains.Sql.Configurations.Utility;
using System;

namespace OpenSettings.Domains.Sql.DataContext
{
    internal static class ModelBuilderExtensions
    {
        private static readonly Lazy<IEntityTypeConfigurationAdapter[]> LazyConfigurations =
            new Lazy<IEntityTypeConfigurationAdapter[]>(
                () =>
                {
                    return new IEntityTypeConfigurationAdapter[]
                    {
                        new AppConfigurationSqlModelConfiguration(),
                        new AppGroupSqlModelConfiguration(),
                        new AppIdentifierMappingSqlModelConfiguration(),
                        new AppInstanceSqlModelConfiguration(),
                        new AppSettingClassSqlModelConfiguration(),
                        new AppSettingHistorySqlModelConfiguration(),
                        new AppSettingSqlModelConfiguration(),
                        new AppSqlModelConfiguration(),
                        new AppTagMappingSqlModelConfiguration(),
                        new AppTagSqlModelConfiguration(),
                        new DataProtectionKeySqlModelConfiguration(),
                        new GlobalConfigurationHistorySqlModelConfiguration(),
                        new GlobalConfigurationSqlModelConfiguration(),
                        new IdentifierSqlModelConfiguration(),
                        new LicenseSqlModelConfiguration(),
                        new LockSqlModelConfiguration(),
                        new LoginEntrySqlModelConfiguration(),
                        new NotificationSqlModelConfiguration(),
                        new ProviderRegistrySqlModelConfiguration(),
                        new TenantSqlModelConfiguration(),
                        new TenantUserMappingSqlModelConfiguration(),
                        new UserClaimMappingSqlModelConfiguration(),
                        new UserClaimSqlModelConfiguration(),
                        new UserGroupMappingSqlModelConfiguration(),
                        new UserGroupNotificationMappingSqlModelConfiguration(),
                        new UserGroupSqlModelConfiguration(),
                        new UserGroupUserClaimMappingSqlModelConfiguration(),
                        new UserNotificationMappingSqlModelConfiguration(),
                        new UserRoleMappingSqlModelConfiguration(),
                        new UserRoleSqlModelConfiguration(),
                        new UserRoleUserClaimMappingSqlModelConfiguration(),
                        new UserRoleUserGroupMappingSqlModelConfiguration(),
                        new UserSqlModelConfiguration(),
                    };
                });

        internal static void UseOpenSettingsModelConfiguration(this ModelBuilder modelBuilder)
        {
            foreach (var configuration in LazyConfigurations.Value)
            {
                configuration.Apply(modelBuilder);
            }
        }
    }
}