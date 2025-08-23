using Microsoft.Extensions.Hosting;

namespace OpenSettings.Services.Interfaces
{
    /// <summary>
    /// Used to synchronize OpenSettings notification.
    /// </summary>
    public interface IOpenSettingsNotificationSyncTimedService : IHostedService
    {
    }
}