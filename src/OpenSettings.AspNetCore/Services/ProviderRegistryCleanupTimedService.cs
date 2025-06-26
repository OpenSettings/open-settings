using Microsoft.Extensions.Logging;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.AspNetCore.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Services
{
    internal sealed class ProviderRegistryCleanupTimedService : TimedHostedService, IProviderRegistryCleanupTimedService
    {
        public ProviderRegistryCleanupTimedService(ILogger<ProviderRegistryCleanupTimedService> logger, Action<TimedHostedServiceOptions> options = null) : base(logger, nameof(ProviderRegistryCleanupTimedService), options)
        {
        }

        protected override ValueTask DoWorkAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Cleaned up '{count}' stale provider registries.", 1);

            return new ValueTask();
        }
    }
}