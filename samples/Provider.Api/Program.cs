using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using System.Threading.Tasks;

namespace Provider.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var openSettingsConfiguration = GetOpenSettingsConfiguration(configuration, DbType.SqlServer);

            await hostBuilder.UseOpenSettingsAsync(openSettingsConfiguration);

            hostBuilder.ConfigureWebHostDefaults(cfg => cfg.UseStartup<Startup>());

            var host = hostBuilder.Build();

            await host.RunAsync();
        }

        /// <summary>
        /// Get settings configuration from 'appsettings.json'.
        /// </summary>
        /// <returns></returns>
        private static OpenSettingsConfiguration GetOpenSettingsConfiguration(IConfiguration configuration, DbType dbType)
        {
            var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

            var settingsServiceConfiguration = configuration.GetSection(nameof(OpenSettingsConfiguration)).Get<OpenSettingsConfiguration>();

            settingsServiceConfiguration.Provider.Orm.ConfigureDbContext = optsBuilder =>
            {
                switch (dbType)
                {
                    case DbType.InMemory:

                        optsBuilder.UseInMemoryDatabase("OpenSettings");

                        break;

                    case DbType.Sqlite:

                        optsBuilder.UseSqlite("Data Source=OpenSettings.db", opts => opts.MigrationsAssembly(migrationsAssembly));

                        break;

                    case DbType.SqlServer:

                        optsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OpenSettings;Integrated Security=True;MultipleActiveResultSets=True", opts => opts.MigrationsAssembly(migrationsAssembly));

                        break;
                }
            };

            return settingsServiceConfiguration;
        }
    }
}