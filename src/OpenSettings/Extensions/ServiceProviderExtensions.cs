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
    public static class ServiceProviderExtensions
    {
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