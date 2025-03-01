using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.MemoryCache;
using OpenSettings.Services.Rest.Interfaces;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class SettingHistoriesRestService : ISettingHistoriesRestService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly HttpClient _httpClient;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;
        private readonly OpenSettingsMemoryCache _openSettingsMemoryCache;

        public SettingHistoriesRestService(
            IDataChangeService dataChangeService,
            HttpClient httpClient,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo,
            OpenSettingsMemoryCache openSettingsMemoryCache)
        {
            _dataChangeService = dataChangeService;
            _httpClient = httpClient;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
            _openSettingsMemoryCache = openSettingsMemoryCache;
        }

        public async Task<IJsonResponse> GetSettingHistoryDataAsync(GetSettingHistoryDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/setting-histories/{input.HistoryId}/data";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetSettingHistoryByIdAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/setting-histories/{input.HistoryIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetSettingHistoryBySlugAsync(GetSettingHistoryInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/setting-histories/slug/{input.HistoryIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetSettingHistoriesAsync(GetSettingHistoriesInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/histories";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse<RestoreSettingHistoryResponse>> RestoreSettingHistoryAsync(RestoreSettingHistoryInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/setting-histories/{input.HistoryId}/restore";

            var body = new
            {
                input.SettingRowVersion,
                input.HistoryRowVersion
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToJsonResponseAsync<RestoreSettingHistoryResponse>(cancellationToken: cancellationToken);

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