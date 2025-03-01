using OpenSettings.Attributes;
using OpenSettings.Models;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace OpenSettings
{
    public static class Constants
    {
        public const string OpenSettingsBasicAuthScheme = "OpenSettingsBasicAuth";
        public const string OpenSettingsCookieScheme = "OpenSettingsCookieScheme";
        public const string OpenSettingsOAuth2Scheme = "OpenSettingsOAuth2";
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
        public const string PackVersionName = "PackVersion";
        public const string PackVersionScoreName = "PackVersionScore";

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