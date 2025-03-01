using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Rest.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Rest
{
    public class AppsRestService : IAppsRestService
    {
        private readonly HttpClient _httpClient;
        private readonly Guid _clientId;

        public AppsRestService(HttpClient httpClient, OpenSettingsConfiguration openSettingsConfiguration)
        {
            _httpClient = httpClient;
            _clientId = openSettingsConfiguration.Client.Id;
        }

        public async Task<IJsonResponse<SyncAppDataResponse>> SyncAppDataAsync(SyncAppDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.Client.Id}/identifiers/{Uri.EscapeDataString(input.IdentifierName)}/sync-data";

            var body = new
            {
                Client = new
                {
                    input.Client.Name,
                    input.Client.Secret
                },
                Configuration = new
                {
                    input.Configuration.AllowAnonymousAccess,
                    input.Configuration.StoreInSeparateFile,
                    input.Configuration.IgnoreOnFileChange,
                    input.Configuration.RegistrationMode,
                    Consumer = new
                    {
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
                    input.Instance.IsDisabled
                }
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ToJsonResponseAsync<SyncAppDataResponse>(cancellationToken: cancellationToken);
                    }

                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            throw new AuthenticationException(
                                "Authentication has failed! Main service disallows anonymous access.");
                        default:

                            var content =
#if NET5_0_OR_GREATER
                                await response.Content.ReadAsStringAsync(cancellationToken);
#else
                                response.Content == null
                                ? string.Empty
                                : await response.Content.ReadAsStringAsync();
#endif

                            throw new Exception($"Error occurred during sync app data. Status code: {response.StatusCode}, Content: {content}");
                    }
                }
            }
        }

        public async Task<IJsonResponse> GetGroupedAppsAsync(GetGroupedAppsInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/grouped?searchTerm={_clientId}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse<FetchAppDataResponse>> FetchAppDataAsync(FetchAppDataInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.ClientId}/identifiers/{Uri.EscapeDataString(input.IdentifierName)}/fetch-data";

            var body = new
            {
                input.ComputedIdentifiers,
                input.StoreInSeparateFile
            };

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync<FetchAppDataResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse<GetAppResponse>> GetAppByIdAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync<GetAppResponse>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse<GetAppResponse>> GetAppBySlugAsync(GetAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync<GetAppResponse>(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetAppsAsync(GetAppsInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException(nameof(GetAppsAsync));

            const string relativeUri = "v1/apps";

            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(input.SearchTerm))
            {
                queryBuilder.Append(nameof(input.SearchTerm), input.SearchTerm);
            }

            using (var response = await _httpClient.GetAsync(queryBuilder.ToString(relativeUri), cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> UpdateAppAsync(UpdateAppInput input, CancellationToken cancellationToken)
        {
            var pathAndQueryBuilder = $"v1/apps/{input.AppId}";

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

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PutAsync(pathAndQueryBuilder, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse<GetRegisteredAppResponse>> GetRegisteredAppAsync(GetRegisteredAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.ClientId}/registered";

            using (var stringContent = new StringContent(JsonSerializer.Serialize(input.ClientSecret), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync<GetRegisteredAppResponse>(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> CreateAppAsync(CreateAppInput input, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();

            const string relativeUri = "v1/apps";

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

            using (var stringContent = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, Constants.ApplicationJson))
            {
                using (var response = await _httpClient.PostAsync(relativeUri, stringContent, cancellationToken))
                {
                    return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
                }
            }
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppIdAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/grouped";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppSlugAsync(GetGroupedAppDataByAppInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/grouped";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppIdAndIdentifierIdAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/grouped";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> GetGroupedAppDataByAppSlugAndIdentifierSlugAsync(GetGroupedAppDataByAppAndIdentifierInput input, CancellationToken cancellationToken = default)
        {
            var relativeUri = $"v1/apps/slug/{input.AppIdOrSlug}/identifiers/{input.IdentifierIdOrSlug}/grouped";

            using (var response = await _httpClient.GetAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }

        public async Task<IJsonResponse> DeleteAppAsync(DeleteAppInput input, CancellationToken cancellationToken)
        {
            var relativeUri = $"v1/apps/{input.AppId}?rowVersion={Uri.EscapeDataString(Convert.ToBase64String(input.RowVersion))}";

            using (var response = await _httpClient.DeleteAsync(relativeUri, cancellationToken))
            {
                return await response.Content.ToJsonResponseAsync(cancellationToken: cancellationToken);
            }
        }
    }
}