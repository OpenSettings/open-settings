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
    /// Provides constant values for authentication schemes and pack version metadata used in OpenSettings.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The name of the HTTP client used for OpenSettings API calls.
        /// </summary>
        public const string OpenSettingsHttpClientName = "OpenSettingsHttpClient";

        /// <summary>
        /// The current embedded index html file namespace for the OpenSettings Spa.
        /// </summary>
        public const string EmbeddedIndexHtmlFileNamespace = "OpenSettings.AspNetCore.Spa.open_settings_spa_dist.browser.index.html";

        public const string BasicSchemeName = "Basic";

        internal static JsonSerializerOptions UnsafeRelaxedJsonSerializerOptions = new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        internal static JsonSerializerOptions UnsafeRelaxedJsonAndWriteIndentedSerializerOptions = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };

        internal const string OpenSettingsApiRoute = "api/settings";
        internal const string DefaultSpaRoutePrefix = "settings";
        internal const string DefaultDocumentTitle = "OpenSettings Spa";
        
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

        internal const string GeneratedSettingsFileNameWithoutExtension = "settings-generated";
        internal const string GeneratedSettingsFileNameWithExtension = "settings-generated.json";

        internal static readonly string GeneratedOpenSettingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings-generated.open-settings.json");

        internal const string DefaultVersion = "1.0.0";
        internal const string RedisSubscriberName = "OpenSettings";
        internal const string DefaultLowercase = "default";
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
    }
}