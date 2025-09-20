using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using OpenSettings.Attributes;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Responses;
using OpenSettings.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace OpenSettings
{
    /// <summary>
    /// Provides constant values for OpenSettings.
    /// </summary>
    internal static class OpenSettingsDefaults
    {
        internal const string DefaultVersion = "1.0.0";

        internal const string DefaultLowercase = "default";

        internal const string DefaultInstanceName = "Default";

        internal const int SortOrderGap = 10;

        internal const string Password = "********";

        public static class Keys
        {
            public const string GeneratorMode = "OPENSETTINGS_GENERATOR_MODE";

            public class AuthService
            {
                public const string ReturnUrl = "returnUrl";
                public const string ApiUrl = "apiUrl";
                public const string StateId = "stateId";
                public const string ClientId = "clientId";
                public const string AccessToken = "accessToken";
            }
        }

        public static class Files
        {
            internal const string SettingsFileNameWithoutExtension = "settings";

            internal const string SettingsFileNameTag = "*settings*";

            internal const string SettingsFileExtension = "json";

            internal const string SettingsFileNameWithExtension = "settings.json";

            internal const string GeneratedSettingsFileNameWithoutExtension = "settings-generated";

            internal const string GeneratedSettingsFileNameWithExtension = "settings-generated.json";

            internal static readonly string GeneratedOpenSettingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings-generated.open-settings.json");
        }

        public static class Spa
        {
            /// <summary>
            /// The current embedded index html file namespace for the OpenSettings Spa.
            /// </summary>
            public const string EmbeddedIndexHtmlFileNamespace = "OpenSettings.AspNetCore.Spa.open_settings_spa_dist.browser.index.html";

            public const string EmbeddedFileNamespace = "OpenSettings.AspNetCore.Spa.open_settings_spa_dist.browser";

            internal const string DefaultRoutePrefix = "settings";

            internal const string DefaultDocumentTitle = "OpenSettings Spa";
        }

        public static class Paging
        {
            internal const int MaxPageSize = 64;

            internal const int MinPageSize = 8;
        }

        public static class Names
        {
            /// <summary>
            /// The name of the HTTP client used for OpenSettings Provider API calls.
            /// </summary>
            public const string ProviderHttpClientName = "OpenSettingsProviderHttpClient";

            public const string BasicSchemeName = "Basic";

            public const string JwtBearerSchemaName = "Bearer";

            internal const string RedisSubscriber = "OpenSettings";

            internal const string Unknown = nameof(Unknown);

            internal const string Https = "https";

            internal const string Http = "http";
        }

        /// <summary>
        /// Provides constant values for content types used in OpenSettings.
        /// </summary>
        public static class ContentTypes
        {
            public const string ApplicationOctetStream = "application/octet-stream";

            public const string TextHtml = "text/html;charset=utf-8";

            internal const string ApplicationJson = "application/json";
        }

        /// <summary>
        /// Provides constant values for header names used in OpenSettings.
        /// </summary>
        public static class Headers
        {
            public const string Authorization = "Authorization";

            public const string CacheControl = "Cache-Control";

            public const string Expires = "Expires";

            public const string Age = "Age";

            public const string Referer = "Referer";

            public const string Location = "Location";

            public const string UserAgent = "User-Agent";

            /// <summary>
            /// The header name used to represent the login type in OpenSettings.
            /// </summary>
            public const string AuthType = "x-os-auth-type";

            /// <summary>
            /// The header name used to represent the authentication method in OpenSettings.
            /// </summary>
            public const string AuthMethod = "x-os-auth-method";

            /// <summary>
            /// The header name used to represent the caller type in OpenSettings.
            /// </summary>
            public const string CallerType = "x-os-caller-type";

            /// <summary>
            /// The header name used to represent the client id in OpenSettings.
            /// </summary>
            public const string ClientId = "x-os-client-id";

            /// <summary>
            /// The header name used to represent the pack version in OpenSettings.
            /// </summary>
            public const string PackVersion = "x-os-pack-version";

            /// <summary>
            /// The header name used to represent the pack version score in OpenSettings.
            /// </summary>
            public const string PackVersionScore = "x-os-pack-version-score";
        }

        /// <summary>
        /// Provides constant values for formatting used in OpenSettings.
        /// </summary>
        public static class Format
        {
            internal const string Comma = ",";

            internal const string CommaWithSpace = ", ";

            internal const string Column = ":";

            internal const string SlugReplacement = "$1-$2";

            internal const string Space = " ";

            internal const string Hyphen = "-";

            internal const string Slash = "/";

            internal const string Dot = ".";

            internal static char[] CommaArray = new char[] { CommaChar };

            internal const char CommaChar = ',';

            internal const char SpaceChar = ' ';

            internal const char DotChar = '.';

            internal const char HyphenChar = '-';

            internal const char SlashChar = '/';

            internal const string PublicCacheControlValue = "public, max-age={0}";
        }

        public static class Serialization
        {
            internal static JsonSerializerOptions UnsafeRelaxedJsonSerializerOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            internal static JsonSerializerOptions UnsafeRelaxedJsonAndWriteIndentedSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true, 
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            internal static readonly JsonSerializerOptions JsonCaseInsensitiveOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        /// <summary>
        /// Provides constant values for API routes used in OpenSettings.
        /// </summary>
        public static class Routes
        {
            internal const string OpenSettingsApiRoute = "api/settings";

            /// <summary>
            /// The V1 API base routes.
            /// </summary>
            public static class V1
            {
                public static class AppGroupsEndpoints
                {
                    /// <summary>
                    /// The AppGroupsController base route.
                    /// </summary>
                    public const string Base = "v1/app-groups";

                    public const string GetAppGroups = Base; // GET
                    public const string CreateAppGroup = Base; // POST
                    public const string GetPaginatedAppGroups = Base + "/paginated"; // GET
                    public const string GetAppGroupById = Base + "/{AppGroupId}"; // GET
                    public const string GetAppGroupBySlug = Base + "/slug/{AppGroupSlug}"; // GET
                    public const string UpdateAppGroup = Base + "/{AppGroupId}"; // PUT
                    public const string UpdateAppGroupSortOrder = Base + "/{AppGroupId}/sort-order"; // POST
                    public const string DragAppGroup = Base + "/{SourceId}/drag/{TargetId}"; // POST
                    public const string ReorderAppGroup = Base + "/reorder"; // POST
                    public const string DeleteAppGroup = Base + "/{AppGroupId}"; // DELETE
                    public const string DeleteUnmappedAppGroups = Base + "/unmapped"; // DELETE
                }

                public static class AppInstancesEndpoints
                {
                    /// <summary>
                    /// The InstancesController base route.
                    /// </summary>
                    public const string Base = "v1/app-instances";

                    public const string DeleteAppInstance = Base + "/{AppInstanceId}"; // DELETE
                }

                public static class AppsEndpoints
                {
                    /// <summary>
                    /// The AppsController base route.
                    /// </summary>
                    public const string Base = "v1/apps";

                    public const string GetApps = Base; // GET
                    public const string CreateApp = Base; // POST
                    public const string GetGroupedApps = Base + "/grouped"; // GET
                    public const string FetchAppData = Base + "/{ClientId:guid}/identifiers/{IdentifierName}/fetch-data"; // POST
                    public const string SyncAppData = Base + "/{ClientId:guid}/identifiers/{IdentifierName}/sync-data"; // POST
                    public const string GetAppById = Base + "/{AppId}"; // GET
                    public const string GetAppBySlug = Base + "/slug/{AppSlug}"; // GET
                    public const string UpdateApp = Base + "/{AppId}"; // PUT
                    public const string DeleteApp = Base + "/{AppId}"; // DELETE
                    public const string GetGroupedAppDataByAppId = Base + "/{AppId}/grouped"; // GET
                    public const string GetGroupedAppDataByAppSlug = Base + "/slug/{AppSlug}/grouped"; // GET
                    public const string GetAppInstancesByAppId = Base + "/{AppId}/instances"; // GET
                    public const string GetAppInstancesByAppSlug = Base + "/slug/{AppSlug}/instances"; // GET
                    public const string CreateAppInstance = Base + "/{ClientId:guid}/instances"; // POST
                    public const string UpdateAppInstance = Base + "/{ClientId:guid}/instances"; // PUT
                    public const string GetRegisteredApp = Base + "/{ClientId:guid}/registered"; // GET
                    public const string GetAppIdentifierMappingsByAppId = Base + "/{AppId}/identifiers"; // GET
                    public const string GetAppIdentifierMappingsByAppSlug = Base + "/slug/{AppSlug}/identifiers"; // GET
                    public const string CreateAppIdentifierMapping = Base + "/{AppId}/identifiers"; // POST
                    public const string GetAppIdentifierMappingByAppIdAndIdentifierId = Base + "/{AppId}/identifiers/{IdentifierId}"; // GET
                    public const string GetAppIdentifierMappingByAppSlugAndIdentifierSlug = Base + "/slug/{AppSlug}/identifiers/{IdentifierSlug}"; // GET
                    public const string GetAppConfigurationByAppIdAndIdentifierId = Base + "/{AppId}/identifiers/{IdentifierId}/configuration"; // GET
                    public const string PatchAppConfiguration = Base + "/{AppId}/identifiers/{IdentifierId}/configuration"; // PATCH
                    public const string DeleteAppIdentifierMapping = Base + "/{AppId}/identifiers/{IdentifierId}"; // DELETE
                    public const string GetAppInstancesByAppIdAndIdentifierId = Base + "/{AppId}/identifiers/{IdentifierId}/instances"; // GET
                    public const string GetAppInstancesByAppSlugAndIdentifierSlug = Base + "/slug/{AppSlug}/identifiers/{IdentifierSlug}/instances"; // GET
                    public const string GetAppSettingsByAppIdAndIdentifierId = Base + "/{AppId}/identifiers/{IdentifierId}/settings"; // GET
                    public const string GetAppSettingsByAppSlugAndIdentifierSlug = Base + "/slug/{AppSlug}/identifiers/{IdentifierSlug}/settings"; // GET
                    public const string UpdateAppIdentifierMappingSortOrder = Base + "/{AppId}/identifiers/{IdentifierId}/sort-order"; // PUT
                    public const string GetGroupedAppDataByAppIdAndIdentifierId = Base + "/{AppId}/identifiers/{IdentifierId}/grouped"; // GET
                    public const string GetGroupedAppDataByAppSlugAndIdentifierSlug = Base + "/slug/{AppSlug}/identifiers/{IdentifierSlug}/grouped"; // GET
                    public const string GetAppSettingsData = Base + "/{AppId}/settings/data"; // GET
                }

                public static class AppSettingHistoriesEndpoints
                {
                    /// <summary>
                    /// The AppSettingHistoriesController base route.
                    /// </summary>
                    public const string Base = "v1/app-setting-histories";

                    public const string GetAppSettingHistoryData = Base + "/{AppSettingHistoryId}/data";
                    public const string GetAppSettingHistoryById = Base + "/{AppSettingHistoryId}";
                    public const string GetAppSettingHistoryBySlug = Base + "/slug/{AppSettingHistorySlug}";
                    public const string RestoreAppSettingHistory = Base + "/{AppSettingHistoryId}/restore";
                }

                public static class AppSettingsEndpoints
                {
                    /// <summary>
                    /// The SettingsController base route.
                    /// </summary>
                    public const string Base = "v1/app-settings";

                    public const string CreateAppSetting = Base;
                    public const string GetAppSettingsLastUpdatedComputedIdentifiers = Base + "/latest-updates";
                    public const string GetAppSettingById = Base + "/{AppSettingId}";
                    public const string UpdateAppSetting = Base + "/{AppSettingId}";
                    public const string DeleteAppSetting = Base + "/{AppSettingId}";
                    public const string GetAppSettingHistories = Base + "/{AppSettingId}/histories";
                    public const string CopyAppSettingTo = Base + "/{AppSettingId}/copy";
                    public const string GetAppSettingData = Base + "/{AppSettingId}/data";
                    public const string UpdateAppSettingData = Base + "/{AppSettingId}/data";
                }

                public static class AppTagsEndpoints
                {
                    /// <summary>
                    /// The TagsController base route.
                    /// </summary>
                    public const string Base = "v1/app-tags";

                    public const string GetAppTags = Base;
                    public const string CreateAppTag = Base;
                    public const string GetPaginatedAppTags = Base + "/paginated";
                    public const string DeleteUnmappedAppTags = Base + "/unmapped";
                    public const string GetAppTagById = Base + "/{AppTagId}";
                    public const string GetAppTagBySlug = Base + "/slug/{AppTagSlug}";
                    public const string UpdateAppTag = Base + "/{AppTagId}";
                    public const string DeleteAppTag = Base + "/{AppTagId}";
                    public const string UpdateAppTagSortOrder = Base + "/{AppTagId}/sort-order";
                    public const string DragAppTag = Base + "/{SourceId}/drag/{TargetId}";
                    public const string ReorderAppTag = Base + "/reorder";
                }

                public static class AuthEndpoints
                {
                    /// <summary>
                    /// The AuthController base route.
                    /// </summary>
                    public const string Base = "v1/auth";

                    public const string GetMe = Base + "/me";
                    public const string Login = Base + "/login";
                    public const string Logout = Base + "/logout";
                }

                public static class IdentifiersEndpoints
                {
                    /// <summary>
                    /// The IdentifiersController base route.
                    /// </summary> 
                    public const string Base = "v1/identifiers";

                    public const string GetIdentifiers = Base;
                    public const string CreateIdentifier = Base;
                    public const string GetPaginatedIdentifiers = Base + "/paginated";
                    public const string DeleteUnmappedIdentifiers = Base + "/unmapped";
                    public const string GetIdentifierById = Base + "/{IdentifierId}";
                    public const string GetIdentifierBySlug = Base + "/slug/{IdentifierSlug}";
                    public const string UpdateIdentifier = Base + "/{IdentifierId}";
                    public const string DeleteIdentifier = Base + "/{IdentifierId}";
                    public const string UpdateIdentifierSortOrder = Base + "/{IdentifierId}/sort-order";
                    public const string DragIdentifier = Base + "/{SourceId}/drag/{TargetId}";
                    public const string ReorderIdentifiers = Base + "/reorder";
                }

                public static class LicensesEndpoints
                {
                    /// <summary>
                    /// The LicensesController base route.
                    /// </summary>
                    public const string Base = "v1/licenses";

                    public const string GetPaginatedLicenses = Base + "/paginated"; // GET
                    public const string GetCurrentLicense = Base + "/current"; // GET
                    public const string SaveLicense = Base; // POST
                    public const string DeleteLicense = Base + "/{ReferenceId}"; // DELETE
                }

                public static class LocalSettingsEndpoints
                {
                    /// <summary>
                    /// The LocalSettingsController base route.
                    /// </summary>
                    public const string Base = "v1/local-settings";

                    public const string GetLocalSettings = Base + "/{ComputedIdentifier:guid}"; // GET
                }

                public static class NotificationsEndpoints
                {
                    /// <summary>
                    /// The NotificationsController base route.
                    /// </summary>
                    public const string Base = "v1/notifications";

                    public const string GetNotifications = Base; // GET
                    public const string GetUserNotifications = Base + "/users/{UserId:guid}"; // GET
                    public const string CreateNotification = Base; // POST
                    public const string MarkNotificationsAsOpened = Base + "/users/{UserId:guid}/open"; // POST
                    public const string MarkNotificationAsViewed = Base + "/{NotificationId:guid}/users/{UserId:guid}/view"; // POST
                    public const string MarkNotificationAsDismissed = Base + "/{NotificationId:guid}/users/{UserId:guid}/dismiss"; // POST
                    public const string DispatchNotificationsToUsers = Base + "/{NotificationId:guid}/users/dispatch"; // POST
                }

                public static class OpenSettingsEndpoints
                {
                    /// <summary>
                    /// The OpenSettingsController base route.
                    /// </summary>
                    public const string Base = "v1/open-settings";

                    public const string GetConfigs = Base + "/configs"; // GET
                    public const string GetConfigData = Base + "/configs-data/{ConfigName}"; // GET
                }

                public static class ProviderEndpoints
                {
                    /// <summary>
                    /// The ProviderController base route.
                    /// </summary>
                    public const string Base = "v1/provider";

                    public const string GetProvider = Base; // GET
                    public const string GetPrimaryProvider = Base + "/primary"; // GET
                }

                public static class TokenEndpoints
                {
                    /// <summary>
                    /// The TokenController base route.
                    /// </summary>
                    public const string Base = "v1/token";

                    public const string GenerateTokenForMachine = Base + "/machine";
                    public const string GetPublicJwks = Base + "/jwks";
                }

                public static class UsersEndpoints
                {
                    /// <summary>
                    /// The UsersController base route.
                    /// </summary>
                    public const string Base = "v1/users";

                    public const string CreateUser = Base; // POST
                    public const string GetPaginatedUsers = Base + "/paginated"; // GET
                    public const string GetUserById = Base + "/{UserId}"; // GET
                    public const string GetUserBySlug = Base + "/slug/{UserSlug}"; // GET
                    public const string UpdateUser = Base + "/{UserId}"; // PUT
                    public const string DeleteUser = Base + "/{UserId}"; // DELETE
                }
            }
        }

        /// <summary>
        /// Provides constant values for authentication schemes used in OpenSettings.
        /// </summary>
        public static class AuthSchemes
        {
            /// <summary>
            /// The authentication scheme for Basic Authentication in OpenSettings.
            /// </summary>
            public const string Basic = "OpenSettingsBasicAuth";

            /// <summary>
            /// The authentication scheme for Cookie-based Authentication in OpenSettings.
            /// </summary>
            public const string Cookie = "OpenSettingsCookieScheme";

            /// <summary>
            /// The authentication scheme for OpenIdConnect Authentication in OpenSettings.
            /// </summary>
            public const string OpenIdConnect = "OpenSettingsOpenIdConnect";

            /// <summary>
            /// The authentication scheme for JWT Bearer Authentication in OpenSettings.
            /// </summary>
            public const string JwtBearer = "OpenSettingsJwtBearer";
        }

        /// <summary>
        /// Provides constant values for claim types used in OpenSettings.
        /// </summary>
        public static class ClaimTypes
        {
            public const string DbUserId = "db_user_id";

            public const string DbUserDisplayName = "db_user_displayName";

            public const string DbUserInitials = "db_user_initials";

            public const string DbUserImage = "db_user_image";

            public const string ClientId = "client_id";

            public const string ClientSecret = "client_secret";

            public const string AccessToken = "access_token";

            public const string RefreshToken = "refresh_token";

            public const string GrantType = "grant_type";

            public const string AuthType = "auth_type";

            public const string AuthMethod = "auth_method";

            public const string JsonTokenId = "jti";
        }

        /// <summary>
        /// Provides constant values for task queue names used in OpenSettings.
        /// </summary>
        internal static class TaskQueues
        {
            internal const string Notification = "notification-queue";

            internal const string DataChange = "data-change-queue";
        }

        /// <summary>
        /// Provides constant values for types used in OpenSettings.
        /// </summary>
        internal static class Types
        {
            internal static Type ComputedIdentifierAttributeType = typeof(ComputedIdentifierAttribute);

            internal static Type RegistrationModeAttributeType = typeof(RegistrationModeAttribute);

            internal static Type StoreInSeparateFileAttributeType = typeof(StoreInSeparateFileAttribute);

            internal static Type CallerType = typeof(CallerType);

            internal static Type LoginType = typeof(AuthType);
        }

        /// <summary>
        /// Provides constant values for separators used in OpenSettings.
        /// </summary>
        public static class Separators
        {
            public static readonly char[] CommaSeparator = { ',' };

            public static readonly char[] SpaceSeparator = { ' ' };

            public static readonly char[] ColumnSeparator = { ':' };
        }

        /// <summary>
        /// Provides constant values for time spans used in OpenSettings.
        /// </summary>
        public static class TimeSpans
        {
            public static TimeSpan TokenExpirySafetyMargin { get; } = TimeSpan.FromSeconds(30);

            public static TimeSpan TokenExpiryTime { get; } = TimeSpan.FromHours(1);
        }

        public static class Flags
        {
            internal const bool IsDbLogEnabled = false;

            internal const bool IsSensitiveDataLoggingEnabled = false;
        }

        internal static class EventIds
        {
            public static class LocalSettingsService // 1000-1049
            {
                public static readonly EventId SyncAppDataInitializationSucceed = new EventId(1000, nameof(SyncAppDataInitializationSucceed));
                public static readonly EventId SyncAppDataInitializationFailed = new EventId(1001, nameof(SyncAppDataInitializationFailed));
                public static readonly EventId UpdateLocalDataAndWriteToDiskFailedWhileDeserializing = new EventId(1002, nameof(UpdateLocalDataAndWriteToDiskFailedWhileDeserializing));
                public static readonly EventId SettingsGeneratedAndShuttingDown = new EventId(1003, nameof(SettingsGeneratedAndShuttingDown));
            }

            public static class OpenSettingsRedisHostedService // 1050-1099
            {
                public static readonly EventId DataChangeNotified = new EventId(1050, nameof(DataChangeNotified));
                public static readonly EventId RedisSubscriptionFailed = new EventId(1051, nameof(RedisSubscriptionFailed));
            }

            public static class ProviderCoordinationTimedService // 1100-1149
            {
                public static readonly EventId MasterTypeProviderNotFound = new EventId(1100, nameof(MasterTypeProviderNotFound));
                public static readonly EventId MasterStale = new EventId(1101, nameof(MasterStale));
                public static readonly EventId MasterHealthy = new EventId(1102, nameof(MasterHealthy));
                public static readonly EventId FailedToStartServices = new EventId(1103, nameof(FailedToStartServices));
                public static readonly EventId FailedToStopServices = new EventId(1104, nameof(FailedToStopServices));
                public static readonly EventId ServicesStartedSuccessfully = new EventId(1105, nameof(ServicesStartedSuccessfully));
                public static readonly EventId ServicesStoppedSuccessfully = new EventId(1106, nameof(ServicesStoppedSuccessfully));
                public static readonly EventId BecameMasterSuccessfully = new EventId(1107, nameof(BecameMasterSuccessfully));
            }

            public static class ProviderOpenIdConnectEvents // 1150-1199
            {
                public static readonly EventId LoginFailedDueToNotFoundExternalUserId = new EventId(1150, nameof(LoginFailedDueToNotFoundExternalUserId));
                public static readonly EventId LoginFailedDueToUserIsDisabled = new EventId(1151, nameof(LoginFailedDueToUserIsDisabled));
                public static readonly EventId OpenIdConnectErrorOccurred = new EventId(1152, nameof(OpenIdConnectErrorOccurred));
            }

            public static class DataValidationService // 1200-1249
            {
                public static readonly EventId FailedToDeserializeComplexType = new EventId(1200, nameof(FailedToDeserializeComplexType));
                public static readonly EventId FailedToValidateComplexProperty = new EventId(1201, nameof(FailedToValidateComplexProperty));
                public static readonly EventId FailedToDeserializeJsonElement = new EventId(1202, nameof(FailedToDeserializeJsonElement));
                public static readonly EventId UnexpectedErrorOccurredWhileDeserializingToType = new EventId(1203, nameof(UnexpectedErrorOccurredWhileDeserializingToType));
                public static readonly EventId UnsupportedTypeEncountered = new EventId(1204, nameof(UnsupportedTypeEncountered));
            }
        }

        /// <summary>
        /// Provides predefined cache keys for various parts of the application. 
        /// These keys are used for caching specific data in the memory cache to improve performance.
        /// </summary>
        internal static class Caches
        {
            internal static OpenSettingsConfiguration OpenSettingsConfiguration { get; set; }

            internal static Dictionary<Guid, LocalSetting> ComputedIdentifierToLocalSetting { get; } = new Dictionary<Guid, LocalSetting>();

            internal static Dictionary<Guid, Guid> TypeIdToComputedIdentifier { get; } = new Dictionary<Guid, Guid>();

            internal static Dictionary<string, LocalSetting> FullNameToLocalSetting { get; } = new Dictionary<string, LocalSetting>();

            internal static Dictionary<string, int> ClassNameToCount { get; } = new Dictionary<string, int>();

            internal static ConcurrentDictionary<object, byte> CacheKeys { get; } = new ConcurrentDictionary<object, byte>();

            internal static ConcurrentDictionary<string, Type> TypeNameToType { get; } = new ConcurrentDictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

            internal static GetAppResponseGroup UngroupedAppsForGetAppResponse { get; } = new GetAppResponseGroup
            {
                Id = "-1",
                Name = "Ungrouped apps",
                SortOrder = 0
            };

            public static GetGroupedAppsResponseAppGroup UngroupedAppsForGetGroupedApps { get; } = new GetGroupedAppsResponseAppGroup
            {
                Id = UngroupedAppsForGetAppResponse.Id,
                Name = UngroupedAppsForGetAppResponse.Name,
                SortOrder = UngroupedAppsForGetAppResponse.SortOrder
            };

            /// <summary>
            /// The cache key for the Settings Spa Middleware Html content.
            /// </summary>
            public static CacheEntryKey OpenSettingsSpaMiddlewareHtmlCacheEntryKey { get; } = new CacheEntry("ossm:html").GetKey();

            public static CacheEntry BasicAuthenticationHandlerAuthTicketCacheEntry { get; } = new CacheEntry("bah:at", TimeSpan.FromMinutes(15));

            /// <summary>   
            /// The cache key for available notification ids, with a 5-minute expiration time.
            /// </summary>
            public static CacheEntry AvailableNotificationIdsCacheEntry { get; } = new CacheEntry("nss:gania", TimeSpan.FromMinutes(5));

            public static CacheEntry RestServiceAuthHandlerAccessTokenCacheEntry { get; } = new CacheEntry("ossrsah:gatk");

            public static CacheEntry TokenServiceGenerateMachineToMachineTokenCacheEntry { get; } = new CacheEntry("ts:gmtmt");

            public static CacheEntry AuthServiceUuidCacheEntry { get; } = new CacheEntry("asu:rt:at", TimeSpan.FromMinutes(5));

            public static CacheEntry OpenSettingsConfigsCacheEntry { get; } = new CacheEntry("oss:gca:configs");

            public static CacheEntryKey OpenSettingsConfigsCacheEntryKey { get; } = OpenSettingsConfigsCacheEntry.GetKey();

            public static CacheEntryKey MachineTokenCacheEntryKey { get; } = new CacheEntry("machine:token").GetKey();

            public static CacheEntryKey AuthServiceIsIdpOnlineCheckCacheEntryKey { get; } = new CacheEntry("as:iioc", TimeSpan.FromMinutes(1)).GetKey();

            public static CacheEntryKey ProviderTokenInfoCacheEntryKey { get; } = new CacheEntry("tss:pti")
            {
                Options =
                {
                    PostEvictionCallbacks =
                    {
                        new PostEvictionCallbackRegistration
                        {
                            EvictionCallback = (key, value, reason, state) =>
                            {
                                var val = (ProviderTokenInfo)value;

                                if (val == null)
                                {
                                    return;
                                }

                                foreach (var signingKey in val.SigningKeys)
                                {
                                    signingKey.Rsa.Dispose();
                                }
                            }
                        }
                    }
                }
            }.GetKey();

            private static OpenSettingsMemoryCache _openSettingsMemoryCache;

            public static OpenSettingsMemoryCache GetOpenSettingsMemoryCache(ILoggerFactory loggerFactory)
            {
                return _openSettingsMemoryCache ?? (_openSettingsMemoryCache = new OpenSettingsMemoryCache(loggerFactory));
            }
        }
    }
}