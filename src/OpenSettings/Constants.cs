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
        /// The current embedded index html file namespace for the OpenSettings Spa.
        /// </summary>
        public const string EmbeddedIndexHtmlFileNamespace = "OpenSettings.AspNetCore.Spa.open_settings_spa_dist.browser.index.html";

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
        internal const string Comma = ",";
        internal const char DotChar = '.';
        internal const char HyphenChar = '-';

        internal const string GeneratedSettingsFileNameWithoutExtension = "settings-generated";
        internal const string GeneratedSettingsFileNameWithExtension = "settings-generated.json";

        internal static readonly string GeneratedOpenSettingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings-generated.open-settings.json");

        internal const string DefaultVersion = "1.0.0";
        internal const string RedisSubscriberName = "OpenSettings";
        internal const string DefaultLowercase = "default";
        internal const string DefaultInstanceName = "Default";
        internal const string ApplicationJson = "application/json";

        internal const int SortOrderGap = 10;
        internal const int MaxPageSize = 64;
        internal const int MinPageSize = 8;
    }
}