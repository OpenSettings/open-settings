using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
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
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsProviderHttpClient();

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
            var relativeUri = $"v1/setting-histories/{input.AppSettingHistoryId}/data";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingHistoryByIdAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/setting-histories/{input.AppHistoryIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingHistoryBySlugAsync(GetAppSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/setting-histories/slug/{input.AppHistoryIdOrSlug}";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}/histories";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<RestoreSettingHistoryResponse>> RestoreAppSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/setting-histories/{input.AppSettingHistoryId}/restore";

            var body = new
            {
                input.SettingRowVersion,
                input.HistoryRowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToResponseAsync<RestoreSettingHistoryResponse>(cancellationToken: cancellationToken);

                    if (response.IsSuccessStatusCode && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.Setting.IdentifierName, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return responseContent;
                }
            }
        }
    }
}