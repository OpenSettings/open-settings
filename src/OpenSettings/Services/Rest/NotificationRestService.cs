using Ogu.Response.Abstractions;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class NotificationRestService : INotificationRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationRestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IResponse> GetNotificationsAsync(GetNotificationsInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.GetNotifications;

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CreateNotificationAsync(CreateNotificationInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.CreateNotification;

            var body = new
            {
                input.Id,
                input.Title,
                input.Message,
                input.Type,
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public Task<IResponse> UpdateNotificationAsync(UpdateNotificationInput input, CancellationToken cancellationToken = default)
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
            //        return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            //    }
            //}
        }

        public Task<IResponse> DeleteNotificationAsync(DeleteNotificationInput input, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //var relativeUri = $"v1/notifications/{input.Id}";

            //using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            //{
            //    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            //}
        }

        public async Task<IResponse> GetUserNotificationsAsync(GetUserNotificationsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.GetUserNotifications,
                new[] { $"{input.UserId}" },
                (nameof(input.IsOpened), input.IsOpened),
                (nameof(input.IsViewed), input.IsViewed),
                (nameof(input.IsDismissed), input.IsDismissed),
                (nameof(input.IsExpired), input.IsExpired),
                (nameof(input.Type), input.Type));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> MarkNotificationsAsOpenedAsync(MarkNotificationsAsOpenedInput input,
            CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationsAsOpened,
                new[] { $"{input.UserId}" });

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> MarkNotificationAsViewedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationAsViewed,
                new[] { $"{input.UserId}" });

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> MarkNotificationAsDismissedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationAsDismissed,
                new[] { $"{input.UserId}" });

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DispatchNotificationsToUsersAsync(DispatchNotificationsToUsersInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.DispatchNotificationsToUsers,
                new[] { $"{input.NotificationId}" });

            using (var response = await GetProviderHttpClient().PostAsync(relativeUri, null, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}