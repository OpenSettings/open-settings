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

        /// <summary>
        /// Initializes a new instance of the <see cref="PollingSettingTimedService"/> class.
        /// </summary>
        /// <param name="localSettingService">The local settings service.</param>
        /// <param name="openSettingsConfiguration">The open settings configuration.</param>
        public PollingSettingTimedService(ILocalSettingService localSettingService, OpenSettingsConfiguration openSettingsConfiguration) : base(openSettingsConfiguration.LoggerFactory.CreateLogger<PollingSettingTimedService>(), nameof(PollingSettingTimedService),
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