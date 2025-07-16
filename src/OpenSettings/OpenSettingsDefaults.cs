using OpenSettings.Attributes;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace OpenSettings
{
    /// <summary>
    /// Provides constant values for OpenSettings.
    /// </summary>
    public static class OpenSettingsDefaults
    {
        internal const string DefaultVersion = "1.0.0";
        internal const string DefaultLowercase = "default";
        internal const string DefaultInstanceName = "Default";

        internal const int SortOrderGap = 10;

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
            /// The name of the HTTP client used for OpenSettings API calls.
            /// </summary>
            public const string HttpClientName = "OpenSettingsHttpClient";

            public const string BasicSchemeName = "Basic";

            internal const string RedisSubscriber = "OpenSettings";
        }

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
            public const string Referer = "Referer";
            public const string Location = "Location";

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

        public static class Format
        {
            public const string Comma = ",";

            internal const string SlugReplacement = "$1-$2";
            internal const string Space = " ";
            internal const string Hyphen = "-";
            internal const string Dot = ".";
            internal const char DotChar = '.';
            internal const char HyphenChar = '-';
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
                /// <summary>
                /// The AppGroupsController base route.
                /// </summary>
                public const string AppGroups = "v1/app-groups";

                /// <summary>
                /// The AppsController base route.
                /// </summary>
                public const string Apps = "v1/apps";

                /// <summary>
                /// The AuthController base route.
                /// </summary>
                public const string Auth = "v1/auth";

                /// <summary>
                /// The IdentifiersController base route.
                /// </summary> 
                public const string Identifiers = "v1/identifiers";

                /// <summary>
                /// The InstancesController base route.
                /// </summary>
                public const string Instances = "v1/instances";

                /// <summary>
                /// The LicensesController base route.
                /// </summary>
                public const string Licenses = "v1/licenses";

                /// <summary>
                /// The LocalSettingsController base route.
                /// </summary>
                public const string LocalSettings = "v1/local-settings";

                /// <summary>
                /// The NotificationsController base route.
                /// </summary>
                public const string Notifications = "v1/notifications";

                /// <summary>
                /// The OpenSettingsController base route.
                /// </summary>
                public const string OpenSettings = "v1/open-settings";

                /// <summary>
                /// The ProviderController base route.
                /// </summary>
                public const string Provider = "v1/provider";

                /// <summary>
                /// The SettingHistoriesController base route.
                /// </summary>
                public const string SettingHistories = "v1/setting-histories";

                /// <summary>
                /// The SettingsController base route.
                /// </summary>
                public const string Settings = "v1/settings";

                /// <summary>
                /// The TagsController base route.
                /// </summary>
                public const string Tags = "v1/tags";

                /// <summary>
                /// The UsersController base route.
                /// </summary>
                public const string Users = "v1/users";
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
            /// The authentication scheme for OAuth2 Authentication in OpenSettings.
            /// </summary>
            public const string OAuth2 = "OpenSettingsOAuth2";

            /// <summary>
            /// The authentication scheme for JWT Bearer Authentication in OpenSettings.
            /// </summary>
            public const string JwtBearer = "OpenSettingsJwtBearer";

            /// <summary>
            /// The authentication scheme for OAuth2 JWT Bearer Authentication in OpenSettings.
            /// </summary>
            public const string OAuth2JwtBearer = "OpenSettingsOAuth2JwtBearer";
        }

        /// <summary>
        /// Provides constant values for claim types used in OpenSettings.
        /// </summary>
        public static class Claims
        {
            public const string DbUserId = "db_user_id";
            public const string DbUserDisplayName = "db_user_displayName";
            public const string DbUserInitials = "db_user_initials";
            public const string DbUserImage = "db_user_image";
        }

        /// <summary>
        /// Provides constant values for task queue names used in OpenSettings.
        /// </summary>
        internal static class TaskQueues
        {
            internal const string Notification = "notification-queue";
            internal const string DataChange = "data-change-queue";
        }

        internal static class Types
        {
            internal static Type ComputedIdentifierAttributeType = typeof(ComputedIdentifierAttribute);
            internal static Type RegistrationModeAttributeType = typeof(RegistrationModeAttribute);
            internal static Type StoreInSeparateFileAttributeType = typeof(StoreInSeparateFileAttribute);
        }

        internal static class Separators
        {
            internal static readonly char[] CommaSeparator = { ',' };
            internal static readonly char[] SpaceSeparator = { ' ' };
        }

        internal static class Caches
        {
            internal static Dictionary<Guid, LocalSetting> ComputedIdentifierToLocalSetting { get; set; } = new Dictionary<Guid, LocalSetting>();
            internal static Dictionary<Guid, Guid> TypeIdToComputedIdentifier { get; set; } = new Dictionary<Guid, Guid>();
            internal static Dictionary<string, LocalSetting> FullNameToLocalSetting { get; set; } = new Dictionary<string, LocalSetting>();
            internal static Dictionary<string, int> ClassNameToCount { get; set; } = new Dictionary<string, int>();
        }
    }
}