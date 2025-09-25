using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class AppSettingHistoryRestService : ISettingHistoryRestService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AppSettingHistoryRestService(
            IDataChangeService dataChangeService,
            IHttpClientFactory httpClientFactory,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _dataChangeService = dataChangeService;
            _httpClientFactory = httpClientFactory;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public async Task<IResponse> GetAppSettingHistoryDataAsync(GetAppSettingHistoryDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryData,
                new[] { $"{input.AppSettingHistoryId}" });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingHistoryByIdAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryById,
                new[] { input.AppHistoryIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingHistoryBySlugAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.GetAppSettingHistoryBySlug,
                new[] { input.AppHistoryIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingHistoriesAsync(GetAppSettingHistoriesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingHistories,
                new[] { $"{input.AppSettingId}" },
                (nameof(input.Excludes), string.Join(OpenSettingsDefaults.Format.Comma, input.Excludes)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<RestoreAppSettingHistoryResponse>> RestoreAppSettingHistoryAsync(RestoreAppSettingHistoryInput input, CancellationToken cancellationToken)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingHistoriesEndpoints.RestoreAppSettingHistory,
                new[] { $"{input.AppSettingHistoryId}" });

            var body = new
            {
                input.SettingRowVersion,
                input.HistoryRowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToResponseAsync<RestoreAppSettingHistoryResponse>(cancellationToken: cancellationToken);

                    if (response.IsSuccessStatusCode && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.IdentifierName, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return responseContent;
                }
            }
        }

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}