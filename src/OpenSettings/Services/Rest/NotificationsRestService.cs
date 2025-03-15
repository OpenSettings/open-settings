using Ogu.Response.Json;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class NotificationsRestService : INotificationsRestService
    {
        private readonly HttpClient _httpClient;

        public NotificationsRestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IJsonResponse> GetNotificationsAsync(GetNotificationsInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/notifications";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CreateNotificationAsync(CreateNotificationInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/notifications";

            var body = new
            {
                input.Id,
                input.Title,
                input.Message,
                input.Type,
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<IJsonResponse> UpdateNotificationAsync(UpdateNotificationInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //var relativeUri = $"v1/notifications/{input.ClientId}";

            //var body = new
            //{
            //};

            //using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            //{
            //    using (var response = await _httpClient.PutAsync(relativeUri, stringContent, cancellationToken))
            //    {
            //        return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            //    }
            //}
        }

        public Task<IJsonResponse> DeleteNotificationAsync(DeleteNotificationInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //var relativeUri = $"v1/notifications/{input.Id}";

            //using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            //{
            //    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            //}
        }

        public async Task<IJsonResponse> GetUserNotificationsAsync(GetUserNotificationsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/notifications/users/{input.UserId}";

            var queryBuilder = new QueryBuilder();

            if (input.IsOpened.HasValue)
            {
                queryBuilder.Append(nameof(input.IsOpened), input.IsOpened);
            }

            if (input.IsViewed.HasValue)
            {
                queryBuilder.Append(nameof(input.IsViewed), input.IsViewed);
            }

            if (input.IsDismissed.HasValue)
            {
                queryBuilder.Append(nameof(input.IsDismissed), input.IsDismissed);
            }

            if (input.IsExpired.HasValue)
            {
                queryBuilder.Append(nameof(input.IsExpired), input.IsExpired);
            }

            if (input.Type.HasValue)
            {
                queryBuilder.Append(nameof(input.Type), input.Type);
            }

            relativeUri = queryBuilder.ToString(relativeUri);

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> MarkNotificationsAsOpenedAsync(MarkNotificationsAsOpenedInput input,
            CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/notifications/users/{input.UserId}/open";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> MarkNotificationAsViewedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/notifications/users/{input.UserId}/view";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> MarkNotificationAsDismissedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/notifications/users/{input.UserId}/dismiss";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DispatchNotificationsToUsersAsync(DispatchNotificationsToUsersInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/notifications/{input.NotificationId}/users/dispatch";

            using (var response = await _httpClient.PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}