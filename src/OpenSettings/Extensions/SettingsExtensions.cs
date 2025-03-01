using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="ISettings"/>.
    /// </summary>
    public static class SettingsExtensions
    {
        /// <summary>
        /// Gets the registration mode associated with the specified <see cref="ISettings"/> object.
        /// If the registration mode is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <param name="setting">The settings object for which the registration mode is to be retrieved.</param>
        /// <returns>
        /// A nullable <see cref="RegistrationMode"/> indicating the registration mode of the setting,
        /// or <c>null</c> if not found.
        /// </returns>
        /// <exception cref="NullReferenceException">Thrown if <param name="setting"></param> null.</exception>
        public static RegistrationMode? GetRegistrationMode(this ISettings setting)
        {
            return SettingsProvider.GetRegistrationMode(setting.GetType().FullName);
        }

        /// <summary>
        /// Gets the local setting data associated with the specified <see cref="ISettings"/> object.
        /// If local setting data is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <param name="setting">The settings object for which the local setting data is to be retrieved.</param>
        /// <returns>
        /// The local setting data associated with the setting object, or <c>null</c> if no data is found.
        /// </returns>
        /// <exception cref="NullReferenceException">Thrown if <param name="setting"></param> null.</exception>
        public static object GetLocalSettingOrDefault(this ISettings setting)
        {
            return SettingsProvider.GetLocalSettingOrDefault(setting.GetType().FullName);
        }

        /// <summary>
        /// Gets the local setting data associated with the specified <see cref="ISettings"/> object, 
        /// cast to the specified type <typeparamref name="T"/>.
        /// If local setting data is found, it is returned; otherwise, <c>null</c> is returned.
        /// </summary>
        /// <typeparam name="T">The type to which the local setting data should be cast. The type must implement <see cref="ISettings"/>.</typeparam>
        /// <param name="setting">The settings object for which the local setting data is to be retrieved.</param>
        /// <returns>
        /// The local setting data associated with the setting object, cast to type <typeparamref name="T"/>, 
        /// or <c>null</c> if no data is found.
        /// </returns>
        /// <exception cref="NullReferenceException">Thrown if <param name="setting"></param> null.</exception>
        public static T GetLocalSettingOrDefault<T>(this ISettings setting) where T : ISettings
        {
            return (T)GetLocalSettingOrDefault(setting);
        }
    }
}