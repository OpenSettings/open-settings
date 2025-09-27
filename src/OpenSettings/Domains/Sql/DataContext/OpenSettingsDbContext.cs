using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.Entities;
using System.Diagnostics;

namespace OpenSettings.Domains.Sql.DataContext
{
    /// <summary>
    /// Represents the database context for OpenSettings, managing the entity sets for various models 
    /// such as applications, configurations, users, roles, settings, and more.
    /// This class is responsible for interacting with the database and performing CRUD operations on the models.
    /// </summary>
    public class OpenSettingsDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenSettingsDbContext"/> class.
        /// </summary>
        /// <param name="opts">The options to configure the context, typically passed from dependency injection.</param>
        public OpenSettingsDbContext(DbContextOptions<OpenSettingsDbContext> opts) : base(opts) { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppGroupSqlModel}"/> for managing AppGroups.
        /// </summary>
        public DbSet<AppGroupSqlModel> AppGroups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppIdentifierMappingSqlModel}"/> for managing AppIdentifierMappings.
        /// </summary>
        public DbSet<AppIdentifierMappingSqlModel> AppIdentifierMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppSqlModel}"/> for managing Apps.
        /// </summary>
        public DbSet<AppSqlModel> Apps { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppTagMappingSqlModel}"/> for managing AppTagMappings.
        /// </summary>
        public DbSet<AppTagMappingSqlModel> AppTagMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppConfigurationSqlModel}"/> for managing Configurations.
        /// </summary>
        public DbSet<AppConfigurationSqlModel> AppConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{IdentifierSqlModel}"/> for managing Identifiers.
        /// </summary>
        public DbSet<IdentifierSqlModel> Identifiers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppInstanceSqlModel}"/> for managing Instances.
        /// </summary>
        public DbSet<AppInstanceSqlModel> AppInstances { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LockSqlModel}"/> for managing Locks.
        /// </summary>
        public DbSet<LockSqlModel> Locks { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{NotificationSqlModel}"/> for managing Notifications.
        /// </summary>
        public DbSet<NotificationSqlModel> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppSettingClassSqlModel}"/> for managing SettingClasses.
        /// </summary>
        public DbSet<AppSettingClassSqlModel> AppSettingClasses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{SettingHistorySqlModel}"/> for managing SettingHistories.
        /// </summary>
        public DbSet<AppSettingHistorySqlModel> AppSettingHistories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{SettingSqlModel}"/> for managing Settings.
        /// </summary>
        public DbSet<AppSettingSqlModel> AppSettings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{AppTagSqlModel}"/> for managing Tags.
        /// </summary>
        public DbSet<AppTagSqlModel> AppTags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserClaimMappingSqlModel}"/> for managing UserClaimMappings.
        /// </summary>
        public DbSet<UserClaimMappingSqlModel> UserClaimMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserClaimSqlModel}"/> for managing UserClaims.
        /// </summary>
        public DbSet<UserClaimSqlModel> UserClaims { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserGroupClaimMappingModel}"/> for managing UserGroupClaimMappings.
        /// </summary>
        public DbSet<UserGroupUserClaimMappingSqlModel> UserGroupClaimMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserGroupMappingSqlModel}"/> for managing UserGroupMappings.
        /// </summary>
        public DbSet<UserGroupMappingSqlModel> UserGroupMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserGroupNotificationMappingSqlModel}"/> for managing UserGroupNotificationMappings.
        /// </summary>
        public DbSet<UserGroupNotificationMappingSqlModel> UserGroupNotificationMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserGroupSqlModel}"/> for managing UserGroups.
        /// </summary>
        public DbSet<UserGroupSqlModel> UserGroups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserNotificationMappingSqlModel}"/> for managing UserNotificationMappings.
        /// </summary>
        public DbSet<UserNotificationMappingSqlModel> UserNotificationMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserRoleClaimMappingModel}"/> for managing UserRoleClaimMappings.
        /// </summary>
        public DbSet<UserRoleUserClaimMappingSqlModel> UserRoleClaimMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserRoleGroupMappingModel}"/> for managing UserRoleGroupMappings.
        /// </summary>
        public DbSet<UserRoleUserGroupMappingSqlModel> UserRoleGroupMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserRoleMappingSqlModel}"/> for managing UserRoleMappings.
        /// </summary>
        public DbSet<UserRoleMappingSqlModel> UserRoleMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserRoleSqlModel}"/> for managing UserRoles.
        /// </summary>
        public DbSet<UserRoleSqlModel> UserRoles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserSqlModel}"/> for managing Users.
        /// </summary>
        public DbSet<UserSqlModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LicenseSqlModel}"/> for managing Licenses.
        /// </summary>
        public DbSet<LicenseSqlModel> Licenses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{ProviderRegistrySqlModel}"/> for managing ProviderRegistries.
        /// </summary>
        public DbSet<ProviderRegistrySqlModel> ProviderRegistries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TenantSqlModel}"/> for managing Tenants.
        /// </summary>
        public DbSet<TenantSqlModel> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TenantUserMappingSqlModel}"/> for managing TenantUserMappings.
        /// </summary>
        public DbSet<TenantUserMappingSqlModel> TenantUserMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GlobalConfigurationSqlModel}"/> for managing GlobalConfigurations.
        /// </summary>
        public DbSet<GlobalConfigurationSqlModel> GlobalConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{GlobalConfigurationHistorySqlModel}"/> for managing GlobalConfigurationHistories.
        /// </summary>
        public DbSet<GlobalConfigurationHistorySqlModel> GlobalConfigurationHistories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LoginEntrySqlModel}"/> for managing LoginEntries.
        /// </summary>
        public DbSet<LoginEntrySqlModel> LoginEntries { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{DataProtectionKey}"/> for managing DataProtectionKeys.
        /// </summary>
        public DbSet<DataProtectionKeySqlModel> DataProtectionKeys { get; set; }

        public virtual void Detach(object entity)
        {
            Entry(entity).State = EntityState.Detached;
        }

        public virtual void DetachRange(params object[] entities)
        {
            foreach (var entity in entities)
            {
                Detach(entity);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseOpenSettingsModelConfiguration();

            base.OnModelCreating(modelBuilder);
        }

        public static OpenSettingsDbContext GetInstance(ProviderConfiguration provider, ILoggerFactory loggerFactory)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OpenSettingsDbContext>();
            provider.Orm.ConfigureDbContext.Invoke(dbContextOptionsBuilder);

            dbContextOptionsBuilder.UseLoggerFactory(OpenSettingsDefaults.Flags.IsDbLogEnabled ? loggerFactory : NullLoggerFactory.Instance);
#if DEBUG
            if (Debugger.IsAttached)
            {
                dbContextOptionsBuilder.EnableSensitiveDataLogging(OpenSettingsDefaults.Flags.IsSensitiveDataLoggingEnabled);
            }
#endif
            dbContextOptionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

            return new OpenSettingsDbContext(dbContextOptionsBuilder.Options);
        }
    }
}