using Microsoft.Extensions.Logging;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    /// <summary>
    /// A service that periodically polls for settings updates.
    /// </summary>
    internal sealed class PollingSettingTimedService : TimedHostedService, IPollingSettingTimedService
    {
        private readonly ILocalSettingService _localSettingService;

        public PollingSettingTimedService(ILogger<PollingSettingTimedService> logger, ILocalSettingService localSettingService, OpenSettingsConfiguration openSettingsConfiguration) : base(logger, nameof(PollingSettingTimedService),
            opts =>
            {
                opts.StartsIn = openSettingsConfiguration.Consumer.PollingSettingsWorker.StartsIn;
                opts.Period = openSettingsConfiguration.Consumer.PollingSettingsWorker.Period;
            })
        {
            _localSettingService = localSettingService;
        }

        protected override async ValueTask DoWorkAsync(CancellationToken cancellationToken)
        {
            await _localSettingService.ReloadSettingsAsync(cancellationToken);
        }
    }
}