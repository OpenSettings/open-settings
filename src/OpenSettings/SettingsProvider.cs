using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;

namespace OpenSettings
{
    /// <summary>
    /// Provides static methods to retrieve local setting data and registration modes 
    /// associated with settings. This class allows accessing settings by their type, 
    /// full name, or other criteria, without needing to instantiate individual setting objects.
    /// </summary>
    public static class SettingsProvider
    {
        /// <summary>
        /// Retrieves the local setting data associated with the specified <typeparamref name="T"/> setting type.
        /// If the setting data is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <typeparam name="T">The type of the setting to retrieve. The type must implement <see cref="ISettings"/>.</typeparam>
        /// <returns>The local setting data associated with the setting, or <c>null</c> if no data is found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <typeparamref name="T"/> is null.</exception>
        public static T GetLocalSettingOrDefault<T>() where T : ISettings
        {
            return (T)GetLocalSettingOrDefault(typeof(T));
        }

        /// <summary>
        /// Retrieves the local setting data associated with the specified <see cref="Type"/> setting type.
        /// If the setting data is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <param name="settingType">The type of the setting to retrieve.</param>
        /// <returns>The local setting data associated with the setting, or <c>null</c> if no data is found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="settingType"/> is null.</exception>
        public static object GetLocalSettingOrDefault(Type settingType)
        {
            return GetLocalSettingOrDefault(settingType.FullName);
        }

        /// <summary>
        /// Retrieves the local setting data associated with the specified setting's full name.
        /// If the setting data is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <param name="settingFullName">The full name of the setting to retrieve.</param>
        /// <returns>The local setting data associated with the setting, or <c>null</c> if no data is found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="settingFullName"/> is null or empty.</exception>
        public static object GetLocalSettingOrDefault(string settingFullName)
        {
            return Constants.FullNameToLocalSetting.TryGetValue(settingFullName, out var localSetting)
                ? localSetting.Instance
                : null;
        }

        /// <summary>
        /// Retrieves the registration mode associated with the specified setting's full name.
        /// If the registration mode is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <param name="settingFullName">The full name of the setting to retrieve the registration mode for.</param>
        /// <returns>A nullable <see cref="RegistrationMode"/> indicating the registration mode of the setting, or <c>null</c> if not found.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="settingFullName"/> is null or empty.</exception>
        public static RegistrationMode? GetRegistrationMode(string settingFullName)
        {
            return Constants.FullNameToLocalSetting.TryGetValue(settingFullName, out var localSetting)
                ? (RegistrationMode?)localSetting.RegistrationMode
                : null;
        }
    }
}