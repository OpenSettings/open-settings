using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Sql.Interfaces
{
    internal interface INotificationsSqlService : INotificationsService
    {
        Task SyncOpenSettingsNotificationsAsync(CancellationToken cancellationToken);
    }
}