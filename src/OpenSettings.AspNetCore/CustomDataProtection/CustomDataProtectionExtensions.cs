using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OpenSettings.AspNetCore.CustomDataProtection
{
    /// <summary>
    /// Provides extension methods for configuring custom data protection in OpenSettings.
    /// </summary>
    internal static class CustomDataProtectionExtensions
    {
        /// <summary>
        /// Configures the data protection builder to persist keys to the OpenSettings database context.
        /// </summary>
        /// <param name="builder">The data protection builder.</param>
        /// <returns>The <see cref="IDataProtectionBuilder"/>.</returns>
        private static IDataProtectionBuilder PersistKeysToOpenSettingsDbContext(this IDataProtectionBuilder builder)
        {
            builder.Services.AddSingleton<IConfigureOptions<KeyManagementOptions>>(_ =>
            {
                return new ConfigureOptions<KeyManagementOptions>(options =>
                {
                    options.XmlRepository = new CustomEfDataProtectionXmlRepository();
                });
            });

            return builder;
        }

        /// <summary>
        /// Creates a data protection provider that uses OpenSettings for key management.
        /// </summary>
        /// <param name="applicationName">The application name.</param>
        /// <returns>The <see cref="IDataProtectionProvider" />.</returns>
        internal static IDataProtectionProvider CreateOpenSettingsDataProtectionProvider(string applicationName)
        {
            var services = new ServiceCollection();

            var builder = services.AddDataProtection();

            builder.SetApplicationName(applicationName);
            builder.PersistKeysToOpenSettingsDbContext();

            return services.BuildServiceProvider().GetRequiredService<IDataProtectionProvider>();
        }
    }
}