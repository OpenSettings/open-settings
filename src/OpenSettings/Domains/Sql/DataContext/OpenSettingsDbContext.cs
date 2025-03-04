using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.Entities;

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
        /// Gets or sets the <see cref="DbSet{ConfigurationSqlModel}"/> for managing Configurations.
        /// </summary>
        public DbSet<ConfigurationSqlModel> Configurations { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{IdentifierSqlModel}"/> for managing Identifiers.
        /// </summary>
        public DbSet<IdentifierSqlModel> Identifiers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{InstanceSqlModel}"/> for managing Instances.
        /// </summary>
        public DbSet<InstanceSqlModel> Instances { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{LockSqlModel}"/> for managing Locks.
        /// </summary>
        public DbSet<LockSqlModel> Locks { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{NotificationSqlModel}"/> for managing Notifications.
        /// </summary>
        public DbSet<NotificationSqlModel> Notifications { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{SettingClassSqlModel}"/> for managing SettingClasses.
        /// </summary>
        public DbSet<SettingClassSqlModel> SettingClasses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{SettingHistorySqlModel}"/> for managing SettingHistories.
        /// </summary>
        public DbSet<SettingHistorySqlModel> SettingHistories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{SettingSqlModel}"/> for managing Settings.
        /// </summary>
        public DbSet<SettingSqlModel> Settings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TagSqlModel}"/> for managing Tags.
        /// </summary>
        public DbSet<TagSqlModel> Tags { get; set; }

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
        public DbSet<UserGroupClaimMappingModel> UserGroupClaimMappings { get; set; }

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
        public DbSet<UserRoleClaimMappingModel> UserRoleClaimMappings { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{UserRoleGroupMappingModel}"/> for managing UserRoleGroupMappings.
        /// </summary>
        public DbSet<UserRoleGroupMappingModel> UserRoleGroupMappings { get; set; }

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

        public static OpenSettingsDbContext GetInstance(ProviderConfiguration provider)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OpenSettingsDbContext>();

            provider.Orm.ConfigureDbContext.Invoke(dbContextOptionsBuilder);

#if DEBUG
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
#endif
            dbContextOptionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

            return new OpenSettingsDbContext(dbContextOptionsBuilder.Options);
        }
    }
}