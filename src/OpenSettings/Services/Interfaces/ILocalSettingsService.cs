using Microsoft.Extensions.Options;
using Ogu.Response.Json;
using OpenSettings.Configurations;
using OpenSettings.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Interfaces
{
    public interface ILocalSettingsService
    {
        /// <summary>
        /// Asynchronously retrieves a settings object of type <typeparamref name="T"/> using the specified identifier name.
        /// </summary>
        /// <param name="identifierName">The identifier name used to retrieve the settings object. It cannot be null, empty, or whitespace.</param>
        /// <param name="cancellationToken">A token used to cancel the asynchronous operation if requested. The default value is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation, with a result of type <typeparamref name="T"/> that implements <see cref="ISettings"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="identifierName"/> is null, empty, or whitespace.</exception>
        /// <exception cref="TaskCanceledException">Thrown if the operation is canceled before completion.</exception>
        Task<T> GetSettingAsync<T>(string identifierName, CancellationToken cancellationToken = default) where T : ISettings;

        /// <summary>
        /// Gets a local setting object of type <typeparamref name="T"/> or returns the default value if not found.
        /// </summary>
        /// <typeparam name="T">The type of the settings object.</typeparam>
        /// <returns>The settings object of type <typeparamref name="T"/> or the default value if not found.</returns>
        T GetSetting<T>() where T : ISettings;

        /// <summary>
        /// Gets a local setting object of type <typeparamref name="T"/> or returns the default value if not found.
        /// If configuration sources are not provided, the default value of <typeparamref name="T"/> is returned. Based on the order of config sources, it will attempt to retrieve the value. 
        /// The config sources are: File, Local, Singleton, Options, OptionsSnapshot, or OptionsMonitor. If the first config source does not contain the value, it will try the second one, and so on.
        /// </summary>
        /// <typeparam name="T">The type of the settings object.</typeparam>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve dependencies.</param>
        /// <param name="configSources">An array of config sources to attempt to fetch the value from, in the given order.</param>
        /// <returns>A task that represents the asynchronous operation, containing the settings object of type <typeparamref name="T"/> or the default value if not found.</returns>
        /// <remarks>
        /// <b>Note:</b> If <paramref name="serviceProvider"/> is resolving from a Singleton, an exception will be thrown if <see cref="IOptionsSnapshot{T}"/> is used because it is scoped and cannot be resolved from a Singleton instance.
        /// </remarks>
        Task<T> GetSettingAsync<T>(IServiceProvider serviceProvider, params ConfigSource[] configSources);

        /// <summary>
        /// Gets a local setting object of type <typeparamref name="T"/> or returns the default value if not found.
        /// If configuration sources are not provided, the default value of <typeparamref name="T"/> is returned. Based on the order of config sources, it will attempt to retrieve the value. 
        /// The config sources are: File, Local, Singleton, Options, OptionsSnapshot, or OptionsMonitor. If the first config source does not contain the value, it will try the second one, and so on.
        /// </summary>
        /// <typeparam name="T">The type of the settings object.</typeparam>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve dependencies.</param>
        /// <param name="cancellationToken">A token used to cancel the operation if requested.</param>
        /// <param name="configSources">An array of config sources to attempt to fetch the value from, in the given order.</param>
        /// <returns>A task that represents the asynchronous operation, containing the settings object of type <typeparamref name="T"/> or the default value if not found.</returns>
        /// <remarks>
        /// <b>Note:</b> If <paramref name="serviceProvider"/> is resolving from a Singleton, an exception will be thrown if <see cref="IOptionsSnapshot{T}"/> is used because it is scoped and cannot be resolved from a Singleton instance.
        /// </remarks>
        Task<T> GetSettingAsync<T>(IServiceProvider serviceProvider, CancellationToken cancellationToken, params ConfigSource[] configSources);

        /// <summary>
        /// Retrieves a local setting object by a unique identifier, based on the provided config sources. Returns the default value if not found.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve dependencies.</param>
        /// <param name="computedIdentifier">A unique identifier for the setting.</param>
        /// <param name="configSources">An array of config sources to attempt to fetch the value from, in the given order.</param>
        /// <returns>A task that represents the asynchronous operation, containing the setting object, or the default value if not found.</returns>
        /// <remarks>
        /// <b>Note:</b> If <paramref name="serviceProvider"/> is resolving from a Singleton, an exception will be thrown if <see cref="IOptionsSnapshot{T}"/> is used because it is scoped and cannot be resolved from a Singleton instance.
        /// </remarks>
        Task<object> GetSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, params ConfigSource[] configSources);

        /// <summary>
        /// Retrieves a local setting object by a unique identifier, based on the provided config sources. Returns the default value if not found.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve dependencies.</param>
        /// <param name="computedIdentifier">A unique identifier for the setting.</param>
        /// <param name="cancellationToken">A token used to cancel the operation if requested.</param>
        /// <param name="configSources">An array of config sources to attempt to fetch the value from, in the given order.</param>
        /// <returns>A task that represents the asynchronous operation, containing the setting object, or the default value if not found.</returns>
        /// <remarks>
        /// <b>Note:</b> If <paramref name="serviceProvider"/> is resolving from a Singleton, an exception will be thrown if <see cref="IOptionsSnapshot{T}"/> is used because it is scoped and cannot be resolved from a Singleton instance.
        /// </remarks>
        Task<object> GetSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, CancellationToken cancellationToken, params ConfigSource[] configSources);

        /// <summary>
        /// When a change notification is triggered, this method attempts to fetch the latest value for the specified <paramref name="computedIdentifier"/> based on recent updates.
        /// </summary>
        /// <param name="computedIdentifier">The identifier for the data that was changed and needs to be reloaded.</param>
        /// <param name="cancellationToken">A token used to cancel the operation if requested. The default is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task SettingDataChangeNotifiedAsync(Guid computedIdentifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempts to reload all settings based on the specified identifier name.
        /// </summary>
        /// <param name="identifierName">The identifier name of the settings to reload. It cannot be null, empty, or whitespace.</param>
        /// <param name="cancellationToken">A token used to cancel the operation if requested. The default is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation. The task result is <c>true</c> if the reload was successful, otherwise <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="identifierName"/> is null, empty, or whitespace.</exception>
        Task<bool> ReloadSettingsAsync(string identifierName, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reloads all settings in the current identifier without specifying a name.
        /// </summary>
        /// <param name="cancellationToken">A token used to cancel the operation if requested. The default is <see cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation. The task result is <c>true</c> if the reload was successful, otherwise <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the identifier name is null, empty, or whitespace.</exception>
        Task<bool> ReloadSettingsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes all locally stored settings associated with the specified identifier name. 
        /// If the identifier name matches the runtime identifier name specified in 
        /// <see cref="OpenSettingsConfiguration.IdentifierName"/>, the operation 
        /// is skipped. Additionally, if the identifier has not been fetched, no settings will 
        /// be removed.
        /// </summary>
        /// <param name="identifierName">
        /// The name of the identifier whose associated local settings are to be deleted.
        /// </param>
        void DeleteSettings(string identifierName);

        /// <summary>
        /// Retrieves the local setting based on the specified computed identifier and configuration source. 
        /// If the setting is not found, an error corresponding to the <paramref name="configSource"/> retrieval is returned. 
        /// If the operation is successful, the retrieved setting is available in the <c>Data</c> field of the response.
        /// </summary>
        /// <param name="serviceProvider">The service provider used to resolve dependencies required for the operation.</param>
        /// <param name="computedIdentifier">A unique identifier used to locate the specific local setting.</param>
        /// <param name="configSource">The source of the configuration that determines how the setting is retrieved.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The result contains a JSON response with the 
        /// retrieved local setting or an error message if the setting is not found.
        /// </returns>
        Task<IJsonResponse> GetLocalSettingAsync(IServiceProvider serviceProvider, Guid computedIdentifier, ConfigSource configSource, CancellationToken cancellationToken = default);
    }
}