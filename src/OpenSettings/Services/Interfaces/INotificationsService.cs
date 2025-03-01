using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface INotificationsService
    {
        Task<IJsonResponse> GetNotificationsAsync(GetNotificationsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> CreateNotificationAsync(CreateNotificationInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> UpdateNotificationAsync(UpdateNotificationInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DeleteNotificationAsync(DeleteNotificationInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> GetUserNotificationsAsync(GetUserNotificationsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> MarkNotificationsAsOpenedAsync(MarkNotificationsAsOpenedInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> MarkNotificationAsViewedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> MarkNotificationAsDismissedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default);

        Task<IJsonResponse> DispatchNotificationsToUsersAsync(DispatchNotificationsToUsersInput input, CancellationToken cancellationToken = default);
    }
}