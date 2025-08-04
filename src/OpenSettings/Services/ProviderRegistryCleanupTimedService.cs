using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    /// <summary>
    /// Timed service that periodically cleans up stale provider registry entries from the database.
    /// </summary>
    internal sealed class ProviderRegistryCleanupTimedService : TimedHostedService, IProviderRegistryCleanupTimedService
    {
        private readonly ProviderRegistryCleanupTimedServiceOptions _options;
        private readonly IServiceProvider _serviceProvider;

        public ProviderRegistryCleanupTimedService(
            ILogger<ProviderRegistryCleanupTimedService> logger,
            IOptions<ProviderRegistryCleanupTimedServiceOptions> providerRegistryCleanupTimedServiceOptions,
            IServiceProvider serviceProvider) 
            : base(logger, nameof(ProviderRegistryCleanupTimedService), timedHostedServiceOptions => Configure(providerRegistryCleanupTimedServiceOptions.Value, timedHostedServiceOptions))
        {
            _options = providerRegistryCleanupTimedServiceOptions.Value;
            _serviceProvider = serviceProvider;
        }

        protected override async ValueTask DoWorkAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<OpenSettingsDbContext>())
                {
                    var threshold = DateTime.UtcNow - _options.CleanupOlderThan;

                    var oldProviderRegistries = await context.ProviderRegistries
                        .AsNoTracking()
                        .Where(p => threshold > p.LastHeartbeatOn)
                        .Select(p => new ProviderRegistrySqlModel { Id = p.Id })
                        .ToArrayAsync(cancellationToken);

                    if (oldProviderRegistries.Length == 0)
                    {
                        return;
                    }

                    context.ProviderRegistries.RemoveRange(oldProviderRegistries);

                    await context.SaveChangesAsync(cancellationToken);

                    Logger.LogInformation("Cleaned up '{count}' stale provider registries.", oldProviderRegistries.Length);
                }
            }
        }

        private static void Configure(ProviderRegistryCleanupTimedServiceOptions providerRegistryCleanupTimedServiceOptions, TimedHostedServiceOptions timedHostedServiceOptions)
        {
            timedHostedServiceOptions.PreservePeriod = true;
            timedHostedServiceOptions.Period = providerRegistryCleanupTimedServiceOptions.CleanupCheckInterval;
        }
    }
}