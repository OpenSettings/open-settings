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
        internal const string SettingsFileNameWithoutExtension = "settings";
        internal const string SettingsFileNameTag = "*settings*";
        internal const string SettingsFileExtension = "json";
        internal const string SettingsFileNameWithExtension = "settings.json";

        internal const string GeneratedSettingsFileNameWithoutExtension = "settings-generated";
        internal const string GeneratedSettingsFileNameWithExtension = "settings-generated.json";

        internal static readonly string GeneratedOpenSettingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings-generated.open-settings.json");

        internal const string DefaultVersion = "1.0.0";
        internal const string RedisSubscriberName = "OpenSettings";
        internal const string DefaultLowercase = "default";
        internal const string DefaultInstanceName = "Default";

        internal const int SortOrderGap = 10;
        internal const int MaxPageSize = 64;
        internal const int MinPageSize = 8;
    }
}