using Ogu.Response;
using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public sealed class SettingsRestService : ISettingsRestService
    {
        private HttpClient HttpClient => _httpClientFactory.CreateOpenSettingsHttpClient();

        private readonly IDataChangeService _dataChangeService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public SettingsRestService(
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

        public async Task<IResponse> GetSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default)
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

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CopySettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default)
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

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToResponseAsync<CopySettingToResponse>(cancellationToken: cancellationToken);

                    if (_dataChangeService != null && response.IsSuccessStatusCode && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.Identifier.Name, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return await response.Content.ReadFromJsonAsync<Response>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/data";

            using (var response = await HttpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await HttpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/settings/latest-updates";

            using (var jsonContent = JsonContent.Create(input))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<GetSettingsLastUpdatedComputedIdentifiersResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetSettingByIdAsync(GetSettingByIdInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.SettingId}";

            var queryBuilder = new QueryBuilder();

            if (input.Excludes.Count > 0)
            {
                queryBuilder.Append(nameof(input.Excludes), string.Join(",", input.Excludes));
            }

            using (var response = await HttpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default)
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

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> CreateSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default)
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

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse<UpdateSettingDataResponse>> UpdateSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/settings/{input.SettingId}/data";

            var body = new
            {
                input.Data,
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await HttpClient.PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToResponseAsync<UpdateSettingDataResponse>(cancellationToken: cancellationToken);

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