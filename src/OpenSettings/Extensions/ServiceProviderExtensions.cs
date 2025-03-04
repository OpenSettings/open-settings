using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenSettings.Configurations;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceProvider"/> to facilitate managing instance status
    /// during application startup and shutdown.
    /// <para>
    /// This class includes the <see cref="UseOpenSettings(IServiceProvider)"/> method that helps update the status of the instance
    /// when the application starts and stops. It's primarily designed for non-ASP.NET applications. 
    /// For ASP.NET applications, it is recommended to use the corresponding extension method specific to <c>IApplicationBuilder</c> for managing application startup and shutdown.
    /// </para>
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Updates the instance status during application startup and shutdown.
        /// <para>
        /// This method is for non-ASP.NET applications. For ASP.NET, use an <c>IApplicationBuilder</c>-based extension instead.
        /// </para>
        /// <para>
        /// Registers actions to mark the instance as active on startup and inactive on shutdown.
        /// </para>
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> to resolve services for updating the instance status.</param>
        public static void UseOpenSettings(this IServiceProvider serviceProvider)
        {
            var hostApplicationLifetime = serviceProvider.GetRequiredService<IHostApplicationLifetime>();
            var clientInfo = serviceProvider.GetRequiredService<ClientInfo>();
            var settingsServiceConfiguration = serviceProvider.GetRequiredService<OpenSettingsConfiguration>();

            var scope = serviceProvider.CreateScope();
            var instancesService = scope.ServiceProvider.GetRequiredService<IInstancesService>();

            var updateInstanceRequest = new UpdateInstanceInput
            {
                ClientId = clientInfo.Id,
                InstanceName = settingsServiceConfiguration.InstanceName,
                IdentifierName = settingsServiceConfiguration.IdentifierName
            };

            hostApplicationLifetime.ApplicationStarted.Register(() =>
            {
                updateInstanceRequest.IsActive = true;

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
        }
    }
}