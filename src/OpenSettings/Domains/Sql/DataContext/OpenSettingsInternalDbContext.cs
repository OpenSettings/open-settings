using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.Entities;

namespace OpenSettings.Domains.Sql.DataContext
{
    internal class OpenSettingsInternalDbContext : DbContext
    {
        public OpenSettingsInternalDbContext(DbContextOptions<OpenSettingsInternalDbContext> opts) : base(opts) { }

        public DbSet<SettingSqlModel> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseOpenSettingsModelConfiguration();

            modelBuilder.Entity<SettingSqlModel>().Ignore(n => n.RowVersion);

            base.OnModelCreating(modelBuilder);
        }

        public static OpenSettingsInternalDbContext GetInstance(ProviderConfiguration provider, ILoggerFactory loggerFactory)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OpenSettingsInternalDbContext>();

            provider.Orm.ConfigureDbContext.Invoke(dbContextOptionsBuilder);

            dbContextOptionsBuilder.UseLoggerFactory(loggerFactory);
#if DEBUG
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
#endif
            dbContextOptionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.AmbientTransactionWarning));

            return new OpenSettingsInternalDbContext(dbContextOptionsBuilder.Options);
        }
    }
}