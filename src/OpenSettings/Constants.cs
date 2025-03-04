using OpenSettings.Attributes;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace OpenSettings
{
    /// <summary>
    /// Provides constant values for authentication schemes and pack version metadata used in OpenSettings.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The authentication scheme for Basic Authentication in OpenSettings.
        /// </summary>
        public const string OpenSettingsBasicAuthScheme = "OpenSettingsBasicAuth";

        /// <summary>
        /// The authentication scheme for Cookie-based Authentication in OpenSettings.
        /// </summary>
        public const string OpenSettingsCookieScheme = "OpenSettingsCookieScheme";

        /// <summary>
        /// The authentication scheme for OAuth2 Authentication in OpenSettings.
        /// </summary>
        public const string OpenSettingsOAuth2Scheme = "OpenSettingsOAuth2";

        /// <summary>
        /// The name used to represent the pack version in OpenSettings.
        /// </summary>
        public const string PackVersionName = "PackVersion";

        /// <summary>
        /// The name used to represent the pack version score in OpenSettings.
        /// </summary>
        public const string PackVersionScoreName = "PackVersionScore";

        internal const string BasicSchemeName = "Basic";

        internal static JsonSerializerOptions UnsafeRelaxedJsonSerializerOptions = new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        internal static JsonSerializerOptions UnsafeRelaxedJsonAndWriteIndentedSerializerOptions = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

        internal const string SettingsFileNameWithoutExtension = "settings";
        internal const string SettingsFileNameTag = "*settings*";
        internal const string SettingsFileExtension = "json";
        internal const string SettingsFileNameWithExtension = "settings.json";

        internal const string SlugReplacement = "$1-$2";
        internal const string Space = " ";
        internal const string Hyphen = "-";
        internal const string Dot = ".";
        internal const char DotChar = '.';
        internal const char HyphenChar = '-';
        internal const char PercentageChar = '%';

        internal const string GeneratedSettingsFileNameWithoutExtension = "settings-generated";
        internal const string GeneratedSettingsFileNameWithExtension = "settings-generated.json";

        internal const string DefaultVersion = "1.0.0";
        internal const string RedisSubscriberName = "OpenSettings";
        internal const string DefaultIdentifierName = "Default";
        internal const string DefaultInstanceName = "Default";
        internal const string NotificationsConfigName = "notifications";
        internal const string ApplicationJson = "application/json";

        internal const int SortOrderGap = 10;
        internal const int MinPageIndex = 1;
        internal const int MaxPageSize = 64;
        internal const int MinPageSize = 8;

        internal static Type ComputedIdentifierAttributeType = typeof(ComputedIdentifierAttribute);
        internal static Type RegistrationModeAttributeType = typeof(RegistrationModeAttribute);
        internal static Type StoreInSeparateFileAttributeType = typeof(StoreInSeparateFileAttribute);

        internal static readonly char[] CommaSeparator = { ',' };
        internal static readonly char[] SpaceSeparator = { ' ' };

        internal static Dictionary<Guid, LocalSetting> ComputedIdentifierToLocalSetting { get; set; } = new Dictionary<Guid, LocalSetting>();
        internal static Dictionary<Guid, Guid> TypeIdToComputedIdentifier { get; set; } = new Dictionary<Guid, Guid>();
        internal static Dictionary<string, LocalSetting> FullNameToLocalSetting { get; set; } = new Dictionary<string, LocalSetting>();
        internal static Dictionary<string, int> ClassNameToCount { get; set; } = new Dictionary<string, int>();

        internal static readonly JsonSerializerOptions JsonCaseInsensitiveOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        internal static class TaskQueues
        {
            internal const string Notification = "notification-queue";
            internal const string DataChange = "data-change-queue";
        }
    }
}