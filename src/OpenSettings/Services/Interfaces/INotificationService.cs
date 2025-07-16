using Ogu.Response.Abstractions;
using OpenSettings.Models.Inputs;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IResponse> GetNotificationsAsync(GetNotificationsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> CreateNotificationAsync(CreateNotificationInput input, CancellationToken cancellationToken = default);

        Task<IResponse> UpdateNotificationAsync(UpdateNotificationInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DeleteNotificationAsync(DeleteNotificationInput input, CancellationToken cancellationToken = default);

        Task<IResponse> GetUserNotificationsAsync(GetUserNotificationsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> MarkNotificationsAsOpenedAsync(MarkNotificationsAsOpenedInput input, CancellationToken cancellationToken = default);

        Task<IResponse> MarkNotificationAsViewedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> MarkNotificationAsDismissedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default);

        Task<IResponse> DispatchNotificationsToUsersAsync(DispatchNotificationsToUsersInput input, CancellationToken cancellationToken = default);
    }
}