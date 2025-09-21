using Ogu.Response.Abstractions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppRestService : IAppRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Guid _clientId;

        public AppRestService(IHttpClientFactory httpClientFactory, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _clientId = openSettingsConfiguration.Client.Id;
        }

        public async Task<IResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.SyncAppData,
                new[] { $"{input.Client.Id}", input.IdentifierName });

            var body = new
            {
                Client = new
                {
                    input.Client.Name,
                    input.Client.Secret
                },
                Configuration = new
                {
                    input.Configuration.StoreInSeparateFile,
                    input.Configuration.IgnoreOnFileChange,
                    input.Configuration.RegistrationMode,
                    Consumer = new
                    {
                        input.Configuration.Consumer.ProviderUrl,
                        input.Configuration.Consumer.RequestEncodings,
                        input.Configuration.Consumer.IsRedisActive,
                        PollingSettingsWorker = new
                        {
                            input.Configuration.Consumer.PollingSettingsWorker.IsActive,
                            input.Configuration.Consumer.PollingSettingsWorker.StartsIn,
                            input.Configuration.Consumer.PollingSettingsWorker.Period,
                        }
                    },
                    Provider = new
                    {
                        Redis = new
                        {
                            input.Configuration.Provider.Redis.IsActive,
                            input.Configuration.Provider.Redis.Configuration,
                            input.Configuration.Provider.Redis.Channel
                        },
                        input.Configuration.Provider.CompressionType,
                        input.Configuration.Provider.CompressionLevel,
                    },
                    Controller = new
                    {
                        input.Configuration.Controller.Route,
                        input.Configuration.Controller.AllowFromExploring,
                        input.Configuration.Controller.RequiresAuthentication,
                        OpenIdConnect = new
                        {
                            input.Configuration.Controller.OpenIdConnect.Authority,
                            input.Configuration.Controller.OpenIdConnect.ClientId,
                            input.Configuration.Controller.OpenIdConnect.ClientSecret,
                            input.Configuration.Controller.OpenIdConnect.SignedOutRedirectUri,
                            input.Configuration.Controller.OpenIdConnect.AllowOfflineAccess,
                            input.Configuration.Controller.OpenIdConnect.IsActive,
                        }
                    },
                    Spa = new
                    {
                        input.Configuration.Spa.RoutePrefix,
                        input.Configuration.Spa.DocumentTitle,
                        input.Configuration.Spa.IsActive
                    }
                },
                Settings = input.Settings.Select(setting => new
                {
                    setting.Data,
                    setting.ComputedIdentifier,
                    setting.Version,
                    setting.DataRestored,
                    setting.DataValidationDisabled,
                    setting.StoreInSeparateFile,
                    setting.IgnoreOnFileChange,
                    setting.RegistrationMode,
                    SettingClass = new
                    {
                        setting.SettingClass.Identifier,
                        setting.SettingClass.Name,
                        setting.SettingClass.FullName,
                        setting.SettingClass.Namespace,
                        setting.SettingClass.Properties,
                        setting.SettingClass.HashCode
                    },
                    setting.HashCode
                }),
                Instance = new
                {
                    input.Instance.InstanceName,
                    input.Instance.DynamicId,
                    input.Instance.Urls,
                    input.Instance.MachineName,
                    input.Instance.Environment,
                    input.Instance.ReloadStrategies,
                    input.Instance.ServiceType,
                    input.Instance.DataAccessType,
                    input.Instance.Version,
                    input.Instance.IsActive
                }
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ToResponseAsync<SyncAppDataResponse>(cancellationToken: cancellationToken);
                    }

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                        case HttpStatusCode.Forbidden:
                            throw new AuthenticationException("Authentication has failed!. Client is not authorized.");

                        default:

                            var content =
#if NET5_0_OR_GREATER
                                await response.Content.ReadAsStringAsync(cancellationToken);
#else
                                response.Content == null
                                ? string.Empty
                                : await response.Content.ReadAsStringAsync();
#endif

                            throw new HttpRequestException($"Error occurred during sync app data. Status code: {response.StatusCode}, Content: {content}.");
                    }
                }
            }
        }

        public async Task<IResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedApps,
                query: RouteHelper.Query((nameof(input.SearchTerm), _clientId)));

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.FetchAppData,
                new[] { $"{input.ClientId}", input.IdentifierName });

            var body = new
            {
                input.ComputedIdentifiers,
                input.StoreInSeparateFile
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<FetchAppDataResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppByAppId,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<GetAppResponse>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetAppByAppSlug,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync<GetAppResponse>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetAppsAsync));

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetApps;

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            using (var response = await GetProviderHttpClient().GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken)
        {
            var pathAndQueryBuilder = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.UpdateApp,
                new[] { $"{input.AppId}" });

            var body = new
            {
                input.DisplayName,
                input.Slug,
                Client = new
                {
                    Name = input.ClientName
                },
                Group = new
                {
                    input.Group.Name
                },
                input.Description,
                input.ImageUrl,
                input.WikiUrl,
                Tags = input.Tags.Select(tag => new
                {
                    tag.Id,
                    tag.Name
                }),
                input.RowVersion
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PutAsync(pathAndQueryBuilder, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetRegisteredApp,
                new[] { $"{input.ClientId}" });

            var body = new
            {
                input.ClientSecret
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync<GetRegisteredAppResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();

            const string relativeUri = OpenSettingsDefaults.Routes.V1.AppsEndpoints.CreateApp;

            var body = new
            {
                input.DisplayName,
                input.Slug,
                Client = new
                {
                    Id = input.Client.Id,
                    Name = input.Client.Name,
                    Secret = input.Client.Secret
                },
                Group = new
                {
                    input.Group.Id,
                    input.Group.Name,
                    input.Group.SortOrder
                },
                input.Description,
                input.ImageUrl,
                input.WikiUrl,
                Tags = input.Tags.Select(tag => new
                {
                    tag.Id,
                    tag.Name,
                    tag.SortOrder
                }).ToArray()
            };

            using (var jsonContent = JsonContent.Create(body))
            {
                using (var response = await GetProviderHttpClient().PostAsync(relativeUri, jsonContent, cancellationToken))
                {
                    return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppId,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppSlug,
                new[] { input.AppIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppIdAndIdentifierId,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.GetGroupedAppDataByAppSlugAndIdentifierSlug,
                new[] { input.AppIdOrSlug, input.IdentifierIdOrSlug });

            using (var response = await GetProviderHttpClient().GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken)
        {
            var relativeUri = RouteHelper.Build(
                OpenSettingsDefaults.Routes.V1.AppsEndpoints.DeleteApp,
                new[] { $"{input.AppId}" },
                RouteHelper.Query((nameof(input.RowVersion), Convert.ToBase64String(input.RowVersion))));

            using (var response = await GetProviderHttpClient().DeleteAsync(relativeUri, cancellationToken))
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