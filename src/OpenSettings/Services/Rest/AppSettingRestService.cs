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
    public sealed class AppSettingRestService : IAppSettingRestService
    {
        private readonly IDataChangeService _dataChangeService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly ProviderInfo _providerInfo;

        public AppSettingRestService(
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

        public async Task<IResponse> GetAppSettingsByAppIdAndIdentifierIdAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingsByAppSlugAndIdentifierSlugAsync(GetSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/settings";

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingsDataAsync(GetSettingsDataInput input, CancellationToken cancellationToken = default)
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

            using (var response = await GetProviderHttpClient().GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CopyAppSettingToAsync(CopySettingToInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}/copy";

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
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
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

        public async Task<IResponse> GetAppSettingDataAsync(GetSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}/data";

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteAppSettingAsync(DeleteSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetAppSettingsLastUpdatedComputedIdentifiersAsync(GetSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = "v1/settings/latest-updates";

            using (var jsonContent = JsonContent.Create(input))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<GetSettingsLastUpdatedComputedIdentifiersResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetAppSettingByIdAsync(GetAppSettingByIdInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}";

            var queryBuilder = new QueryBuilder();

            if (input.Excludes.Count > 0)
            {
                queryBuilder.Append(nameof(input.Excludes), string.Join(",", input.Excludes));
            }

            using (var response = await GetProviderHttpClient().GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateSettingAsync(UpdateSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}";

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
                using (var response = await GetProviderHttpClient().PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> CreateAppSettingAsync(CreateSettingInput input, CancellationToken cancellationToken = default)
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
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse<UpdateSettingDataResponse>> UpdateAppSettingDataAsync(UpdateSettingDataInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/settings/{input.AppSettingId}/data";

            var body = new
            {
                input.Data,
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PutAsync(relativeUri, jsonContent, cancellationToken))
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

        private HttpClient GetProviderHttpClient()
        {
            return _httpClientFactory.CreateOpenSettingsProviderHttpClient();
        }
    }
}