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
using OpenSettings.Helpers;

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

        public async Task<IResponse> GetAppSettingsByAppIdAndIdentifierIdAsync(GetAppSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsByAppIdAndIdentifierId,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingsByAppSlugAndIdentifierSlugAsync(GetAppSettingsByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsByAppSlugAndIdentifierSlug,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppSettingsDataAsync(GetAppSettingsDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppSettingsData,
                new[] { input.AppId },
                (nameof(input.IdentifierId), input.IdentifierId), (nameof(input.Ids), string.Join(OpenSettingsDefaults.Format.Comma, input.Ids)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> CopyAppSettingToAsync(CopyAppSettingToInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.CopyAppSettingTo,
                new[] { $"{input.AppSettingId}" });

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
                    var responseContent = await response.Content.ToResponseAsync<CopyAppSettingToResponse>(cancellationToken: cancellationToken);

                    if (_dataChangeService != null && response.IsSuccessStatusCode && (!_openSettingsConfiguration.Consumer.IsRedisActive || !_providerInfo.Redis.IsActive))
                    {
                        await _dataChangeService.NotifyChangeAsync(responseContent.Data.ClientId, responseContent.Data.Identifier.Name, responseContent.Data.Setting.ComputedIdentifier, CancellationToken.None);
                    }

                    return await response.Content.ReadFromJsonAsync<Response>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetAppSettingDataAsync(GetAppSettingDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingData,
                new[] { $"{input.AppSettingId}" });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteAppSettingAsync(DeleteAppSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.DeleteAppSetting,
                new[] { $"{input.AppSettingId}" },
                (nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion)));

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<GetSettingsLastUpdatedComputedIdentifiersResponse>> GetAppSettingsLastUpdatedComputedIdentifiersAsync(GetAppSettingsLastUpdatedComputedIdentifiersInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingsLastUpdatedComputedIdentifiers;

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
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.GetAppSettingById,
                new[] { $"{input.AppSettingId}" },
                (nameof(input.Excludes), string.Join(OpenSettingsDefaults.Format.Comma, input.Excludes)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppSettingAsync(UpdateAppSettingInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.UpdateAppSetting,
                new[] { $"{input.AppSettingId}" });

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

        public async Task<IResponse> CreateAppSettingAsync(CreateAppSettingInput input, CancellationToken cancellationToken = default)
        {
            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.CreateAppSetting;

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

        public async Task<IResponse<UpdateAppSettingDataResponse>> UpdateAppSettingDataAsync(UpdateAppSettingDataInput input, CancellationToken cancellationToken)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppSettingsEndpoints.UpdateAppSettingData,
                new[] { $"{input.AppSettingId}" });

            var body = new
            {
                input.Data,
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PutAsync(relativeUri, jsonContent, cancellationToken))
                {
                    var responseContent = await response.Content.ToResponseAsync<UpdateAppSettingDataResponse>(cancellationToken: cancellationToken);

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