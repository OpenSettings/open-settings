using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class SettingsRestService : ISettingsRestService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly HttpClient _httpClient;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public SettingsRestService(
            IDataChangeService dataChangeService,
            HttpClient httpClient,
            OpenSettingsConfiguration openSettingsConfiguration,
            ProviderInfo providerInfo)
        {
            _dataChangeService = dataChangeService;
            _httpClient = httpClient;
            _openSettingsConfiguration = openSettingsConfiguration;
            _providerInfo = providerInfo;
        }

        public async Task<IJsonResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppId}/settings/data";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.IdentifierId))
            {
                queryBuilder.Append(nameof(input.IdentifierId), input.IdentifierId);
            }

            if (input.Ids.Length > 0)
            {
                queryBuilder.Append(nameof(input.Ids), string.Join(",", input.Ids));
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                var deserializableJsonResponse = new DeserializableJsonResponse
                {
                    AdditionalData =
                    {
                        { "serializedResponse", await response.Content.ReadAsStringAsync() }
                    }
                };

                return deserializableJsonResponse.ToJsonResponse();
                //return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/copy";

            var body = new
            {
                input.TargetAppId,
                Identifier = new
                {
                    Id = input.IdentifierId,
                    Name = input.IdentifierName
                }
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToJsonResponseAsync<CopySettingToResponse>(cancellationToken: cancellationToken);

                    if (_dataChangeService != null && response.IsSuccessStatusCode && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.Identifier.Name, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return await response.Content.ReadFromJsonAsync<JsonResponse>(cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/data";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/settings/latest-updates";

            using (var stringContent = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync<GetSettingsLastUpdatedComputedIdentifiersResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}";

            var queryBuilder = new QueryBuilder();

            if (input.Excludes.Count > 0)
            {
                queryBuilder.Append(nameof(input.Excludes), string.Join(",", input.Excludes));
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}";

            var body = new
            {
                input.ComputedIdentifier,
                input.DataValidationDisabled,
                RowVersion = input.SettingRowVersion,
                Class = new
                {
                    Namespace = input.ClassNamespace,
                    Name = input.ClassName,
                    FullName = input.ClassFullName,
                    RowVersion = input.ClassRowVersion
                }
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PutAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/settings";

            var body = new
            {
                input.AppId,
                input.Data,
                input.ComputedIdentifier,
                input.IdentifierId,
                Class = new
                {
                    Namespace = input.ClassNamespace,
                    Name = input.ClassName,
                    FullName = input.ClassFullName,
                }
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/data";

            var body = new
            {
                input.Data,
                input.RowVersion
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PutAsync(relativeUri, stringContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToJsonResponseAsync<UpdateSettingDataResponse>(cancellationToken: cancellationToken);

                    if (_dataChangeService != null && responseContent.Success && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.Setting.IdentifierName, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return responseContent;
                }
            }
        }
    }
}