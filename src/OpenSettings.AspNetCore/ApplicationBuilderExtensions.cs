using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OpenSettings.AspNetCore.Spa;
using OpenSettings.Configurations;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Updates instance status when the application is starting or stopping.  
        /// <para>This includes updating the instance's activity status, urls, and other relevant data.</para>
        /// <para>Throws an exception if <see cref="Extensions.HostBuilderExtensions.UseOpenSettingsAsync(IHostBuilder, OpenSettingsConfiguration, Func{Microsoft.Extensions.Configuration.IConfiguration, Task},System.Type[])" /> and <see cref="Extensions.ServiceCollectionExtensions.AddOpenSettings"/> have not been configured yet.</para>
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance used to configure the application's request pipeline.</param>
        /// <returns>The modified <see cref="IApplicationBuilder"/> instance.</returns>
        /// <exception cref="Exception">Thrown if settings have not been properly configured.</exception>
        public static IApplicationBuilder UseOpenSettings(this IApplicationBuilder app)
        {
            var hostApplicationLifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            var settingsServiceConfiguration = app.ApplicationServices.GetService<OpenSettingsConfiguration>();

            if (settingsServiceConfiguration == null)
            {
                throw new Exception("'AddOpenSettings()' registration required!");
            }

            var scope = app.ApplicationServices.CreateScope();

            var instancesService = scope.ServiceProvider.GetRequiredService<IInstancesService>();

            var updateInstanceRequest = new UpdateInstanceInput
            {
                ClientId = settingsServiceConfiguration.Client.Id,
                ClientSecret = settingsServiceConfiguration.Client.Secret,
                InstanceName = settingsServiceConfiguration.InstanceName,
                IdentifierName = settingsServiceConfiguration.IdentifierName
            };

            hostApplicationLifetime.ApplicationStarted.Register(() =>
            {
                var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
                var urls = serverAddressesFeature?.Addresses?.ToArray() ?? Array.Empty<string>();

                updateInstanceRequest.IsActive = true;
                updateInstanceRequest.Urls = urls;

                _ = instancesService.UpdateInstanceAsync(updateInstanceRequest, CancellationToken.None);
            });

            hostApplicationLifetime.ApplicationStopping.Register(() =>
            {
                updateInstanceRequest.IsActive = false;

                _ = instancesService.UpdateInstanceAsync(updateInstanceRequest, CancellationToken.None).ContinueWith((c) =>
                {
                    scope.Dispose();

                    return Task.CompletedTask;
                });
            });

            return app;
        }

        /// <summary>
        /// Registers the open settings spa middleware and configures its options.
        /// This method must be called after <c>AddOpenSettingsController</c> has been configured,
        /// otherwise, a <see cref="NullReferenceException"/> will be thrown.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> used to configure the request pipeline.</param>
        /// <param name="configure">An optional delegate to configure <see cref="SettingsSpaOptions"/>.</param>
        /// <returns>Returns the <see cref="IApplicationBuilder"/> to allow further configuration in the middleware pipeline.</returns>
        /// <exception cref="NullReferenceException">Thrown if <c>AddOpenSettingsController</c> was not called before this method.</exception>
        public static IApplicationBuilder UseOpenSettingsSpa(this IApplicationBuilder app, Action<SettingsSpaOptions> configure = null)
        {
            _ = app.ApplicationServices.GetService<ControllerOptions>() ?? throw new NullReferenceException("OpenSettingsController isn't configured. To configure it, append 'AddOpenSettingsController' to the MvcBuilder.");

#if DEBUG
            string[] GetLocalIPv4Address()
            {
                var ipAddresses = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .SelectMany(networkInterface => networkInterface.GetIPProperties().UnicastAddresses)
                    .Where(u => u.Address.AddressFamily == AddressFamily.InterNetwork).Select(i => $"http://{i.Address}:4200")
                    .ToArray();

                return ipAddresses.Length > 0 ? ipAddresses : throw new Exception("Ipv4 address couldn't found");
            }

            var ipv4Address = GetLocalIPv4Address();

            app.UseCors(p => p.WithOrigins(ipv4Address.Concat(new[]
            {
                "http://localhost:4200",
                "http://0.0.0.0:4200"
            }).ToArray()).AllowAnyMethod().AllowAnyHeader());
#endif

            SettingsSpaOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<SettingsSpaOptions>>().Value;
                configure?.Invoke(options);
            }

            //app.UseStaticFiles(new StaticFileOptions // Todo: Check if needed
            //{
            //    FileProvider = new EmbeddedFileProvider(typeof(SettingsSpaMiddleware).Assembly, OpenSettings.AspNetCore.Spa.Constants.EmbeddedAssetsDirectoryNamespace),
            //    RequestPath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "/assets" : $"/{options.RoutePrefix}/assets"
            //});

            return app.UseMiddleware<SettingsSpaMiddleware>(options);
        }
    }
}