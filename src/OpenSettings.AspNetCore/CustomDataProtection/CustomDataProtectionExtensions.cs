using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace OpenSettings.AspNetCore.CustomDataProtection
{
    internal static class CustomDataProtectionExtensions
    {
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