using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.DataContext
{
    public class OpenSettingsDbContext : DbContext
    {
        public OpenSettingsDbContext(DbContextOptions<OpenSettingsDbContext> opts) : base(opts) { }

        public DbSet<AppGroupSqlModel> AppGroups { get; set; }

        public DbSet<AppIdentifierMappingSqlModel> AppIdentifierMappings { get; set; }

        public DbSet<AppSqlModel> Apps { get; set; }

        public DbSet<AppTagMappingSqlModel> AppTagMappings { get; set; }

        public DbSet<ConfigurationSqlModel> Configurations { get; set; }

        public DbSet<IdentifierSqlModel> Identifiers { get; set; }

        public DbSet<InstanceSqlModel> Instances { get; set; }

        public DbSet<LockSqlModel> Locks { get; set; }

        public DbSet<NotificationSqlModel> Notifications { get; set; }

        public DbSet<SettingClassSqlModel> SettingClasses { get; set; }

        public DbSet<SettingHistorySqlModel> SettingHistories { get; set; }

        public DbSet<SettingSqlModel> Settings { get; set; }

        public DbSet<TagSqlModel> Tags { get; set; }

        public DbSet<UserClaimMappingSqlModel> UserClaimMappings { get; set; }

        public DbSet<UserClaimSqlModel> UserClaims { get; set; }

        public DbSet<UserGroupClaimMappingModel> UserGroupClaimMappings { get; set; }

        public DbSet<UserGroupMappingSqlModel> UserGroupMappings { get; set; }

        public DbSet<UserGroupNotificationMappingSqlModel> UserGroupNotificationMappings { get; set; }

        public DbSet<UserGroupSqlModel> UserGroups { get; set; }

        public DbSet<UserNotificationMappingSqlModel> UserNotificationMappings { get; set; }

        public DbSet<UserRoleClaimMappingModel> UserRoleClaimMappings { get; set; }

        public DbSet<UserRoleGroupMappingModel> UserRoleGroupMappings { get; set; }

        public DbSet<UserRoleMappingSqlModel> UserRoleMappings { get; set; }

        public DbSet<UserRoleSqlModel> UserRoles { get; set; }

        public DbSet<UserSqlModel> Users { get; set; }

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