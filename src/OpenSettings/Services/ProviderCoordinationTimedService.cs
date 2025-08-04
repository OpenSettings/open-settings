using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    /// <summary>
    /// Responsible to become master and heartbeat check.
    /// </summary>
    internal sealed class ProviderCoordinationTimedService : TimedHostedService, IProviderCoordinationTimedService
    {
        public static Guid InstanceId { get; } = Guid.NewGuid();

        private bool? _isMaster;

        private readonly IServiceProvider _serviceProvider;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly TimeSpan _masterStaleTimeout;

        private readonly AcquireLockInput _masterAcquireLockInput = new AcquireLockInput
        {
            Key = $"{nameof(ProviderCoordinationTimedService)}:master",
            Owner = Environment.MachineName,
            Timeout = TimeSpan.FromSeconds(10)
        };

        public ProviderCoordinationTimedService(ILogger<ProviderCoordinationTimedService> logger, IOptions<ProviderCoordinationTimedServiceOptions> providerCoordinationTimedServiceOpts, IServiceProvider serviceProvider, OpenSettingsConfiguration openSettingsConfiguration) : base(logger, nameof(ProviderCoordinationTimedService), timedHostedServiceOpts => Configure(providerCoordinationTimedServiceOpts.Value, timedHostedServiceOpts))
        {
            _serviceProvider = serviceProvider;

            var providerCoordinationTimedServiceOptsValue = providerCoordinationTimedServiceOpts.Value;
            _openSettingsConfiguration = openSettingsConfiguration;

            _masterStaleTimeout = TimeSpan.FromMilliseconds(providerCoordinationTimedServiceOptsValue.MasterCheckInterval + providerCoordinationTimedServiceOptsValue.GraceBuffer);
        }

        protected override async ValueTask DoWorkAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using(var context = scope.ServiceProvider.GetRequiredService<OpenSettingsDbContext>())
                {
                    var providerRegistry = await context.ProviderRegistries
                        .AsNoTracking()
                        .Where(p => p.Id == InstanceId)
                        .OrderBy(p => p.Type)
                        .Select(p => new { p.Type })
                        .FirstOrDefaultAsync(cancellationToken);

                    if (providerRegistry == null)
                    {
                        await RegisterProviderAsync(context, cancellationToken);
                    }
                    else
                    {
                        await UpdateHeartbeatOnAsync(context, cancellationToken);

                        if (_isMaster.HasValue)
                        {
                            if (_isMaster.Value && providerRegistry.Type != ProviderRegistryType.Master)
                            {
                                await StopMasterProviderServices(cancellationToken);

                                _isMaster = false;
                            }
                            else if (!_isMaster.Value && providerRegistry.Type == ProviderRegistryType.Master)
                            {
                                var threshold = DateTime.UtcNow - _masterStaleTimeout;

                                var anyMasterProviderOtherThanCurrent = await context.ProviderRegistries
                                    .AsNoTracking()
                                    .AnyAsync(p => p.Type == ProviderRegistryType.Master && p.Id != InstanceId && p.LastHeartbeatOn >= threshold, cancellationToken);

                                if (!anyMasterProviderOtherThanCurrent)
                                {
                                    await StartMasterProviderServicesAsync(cancellationToken);

                                    _isMaster = true;
                                }
                            }
                        }
                    }

                    if (await IsMasterStaleAsync(context, cancellationToken))
                    {
                        var lockService = scope.ServiceProvider.GetRequiredService<ILockService>();

                        if (await lockService.AcquireLockAsync(_masterAcquireLockInput, cancellationToken))
                        {
                            await BecomeMasterAsync(context, cancellationToken);

                            Logger.LogInformation("Instance '{instanceId}' for ClientId '{clientId}' successfully became master.", InstanceId, _openSettingsConfiguration.Client.Id);

                            _isMaster = true;

                            await StartMasterProviderServicesAsync(cancellationToken);
                        }
                        else
                        {
                            if (_isMaster.HasValue && _isMaster.Value)
                            {
                                await StopMasterProviderServices(cancellationToken);
                            }

                            _isMaster = false;
                        }
                    }
                    else if (!_isMaster.HasValue)
                    {
                        _isMaster = false;
                    }
                }
            }
        }

        private IHostedService[] _masterProviderServices;

        private async Task StartMasterProviderServicesAsync(CancellationToken cancellationToken)
        {
            _masterProviderServices = _masterProviderServices?.Length > 0 ? _masterProviderServices : new IHostedService[]
            {
                _serviceProvider.GetRequiredService<IOpenSettingsNotificationSyncTimedService>(),
                _serviceProvider.GetRequiredService<IProviderRegistryCleanupTimedService>()
            };

            var tasksForStart = _masterProviderServices.Select(service => service.StartAsync(cancellationToken)
                .ContinueWith(task =>
                {
                    var serviceName = service.GetType().Name;

                    if (task.IsFaulted)
                    {
                        Logger.LogError(task.Exception, "Failed to start service: '{serviceName}'.",
                            serviceName);
                    }
                    else
                    {
                        Logger.LogInformation("Service started successfully: '{serviceName}'.", serviceName);
                    }
                }, cancellationToken));

            await Task.WhenAll(tasksForStart);
        }

        private async Task StopMasterProviderServices(CancellationToken cancellationToken)
        {
            if (_masterProviderServices == null)
            {
                return;
            }

            var tasksForStop = _masterProviderServices.Select(service => service.StopAsync(cancellationToken)
                .ContinueWith(task =>
                {
                    var serviceName = service.GetType().Name;

                    if (task.IsFaulted)
                    {
                        Logger.LogError(task.Exception, "Failed to stop service: '{serviceName}'", serviceName);
                    }
                    else
                    {
                        Logger.LogInformation("Service stopped successfully: '{serviceName}'", serviceName);
                    }
                }, cancellationToken));

            await Task.WhenAll(tasksForStop);
        }

        private async Task RegisterProviderAsync(OpenSettingsDbContext context, CancellationToken cancellationToken)
        {
            var clientId = _openSettingsConfiguration.Client.Id;
            var clientIdLowercase = $"{clientId}".ToLowerInvariant();
            var currentTime = DateTime.UtcNow;

            var providerRegistry = new ProviderRegistrySqlModel
            {
                Id = InstanceId,
                Type = ProviderRegistryType.Slave,
                ClientId = clientId,
                ClientIdLowercase = clientIdLowercase,
                Scheme = ProviderRegistryScheme.Unset,
                Region = string.Empty,
                Version = _openSettingsConfiguration.Client.Version,
                PackVersion = OpenSettingsAssemblyInfo.Instance.PackVersion,
                CreatedOn = currentTime,
                LastHeartbeatOn = currentTime
            };

            var instanceUrlResolver = _serviceProvider.GetService<IInstanceUrlResolverService>();

            if (instanceUrlResolver != null && Uri.TryCreate(instanceUrlResolver.ResolveUrls().FirstOrDefault(), UriKind.RelativeOrAbsolute, out var uri))
            {
                switch (uri.Scheme.ToLowerInvariant())
                {
                    case "tcp":
                        providerRegistry.Scheme = ProviderRegistryScheme.Tcp;
                        break;
                    case "grpc":
                        providerRegistry.Scheme = ProviderRegistryScheme.Grpc;
                        break;
                    case "http":
                        providerRegistry.Scheme = ProviderRegistryScheme.Http;
                        break;
                    case "https":
                        providerRegistry.Scheme = ProviderRegistryScheme.Https;
                        break;
                    case "ws":
                        providerRegistry.Scheme = ProviderRegistryScheme.WebSocket;
                        break;
                    case "wss":
                        providerRegistry.Scheme = ProviderRegistryScheme.WebSocketSecure;
                        break;
                    default:
                        providerRegistry.Scheme = ProviderRegistryScheme.Unset;
                        break;
                }

                providerRegistry.Host = uri.Host;
                providerRegistry.Port = uri.Port;
            }

            var entry = context.ProviderRegistries.Add(providerRegistry);

            await context.SaveChangesAsync(cancellationToken);

            entry.State = EntityState.Detached;
        }

        private static async Task UpdateHeartbeatOnAsync(OpenSettingsDbContext context, CancellationToken cancellationToken)
        {
            var providerRegistry = new ProviderRegistrySqlModel { Id = InstanceId }; // Todo: Can InstanceId not found in the provider registry when this get called?

            var entry = context.ProviderRegistries.Attach(providerRegistry);

            providerRegistry.LastHeartbeatOn = DateTime.UtcNow;

            entry.Property(p => p.LastHeartbeatOn).IsModified = true;

            await context.SaveChangesAsync(cancellationToken);

            entry.State = EntityState.Detached;
        }

        private static async Task BecomeMasterAsync(OpenSettingsDbContext context, CancellationToken cancellationToken)
        {
            var masterProviderRegistry = new ProviderRegistrySqlModel
            {
                Id = InstanceId,
                Type = ProviderRegistryType.Master,
                LastHeartbeatOn = DateTime.UtcNow
            };

            var entry = context.ProviderRegistries.Attach(masterProviderRegistry);

            entry.Property(p => p.Type).IsModified = true;
            entry.Property(p => p.LastHeartbeatOn).IsModified = true;

            var oldMasterProviders = await context.ProviderRegistries.AsNoTracking()
                .Where(p => p.Id != InstanceId && p.Type == ProviderRegistryType.Master)
                .Select(p => new ProviderRegistrySqlModel { Id = p.Id })
                .ToArrayAsync(cancellationToken);

            var oldMasterProviderEntries = oldMasterProviders.Select(p =>
            {
                var oldProviderEntry = context.ProviderRegistries.Attach(p);

                p.Type = ProviderRegistryType.Slave;

                oldProviderEntry.Property(pp => pp.Type).IsModified = true;

                return oldProviderEntry;
            }).ToArray();

            await context.SaveChangesAsync(cancellationToken);

            entry.State = EntityState.Detached;

            foreach (var oldMasterProviderEntry in oldMasterProviderEntries)
            {
                oldMasterProviderEntry.State = EntityState.Detached;
            }
        }

        private async Task<bool> IsMasterStaleAsync(OpenSettingsDbContext context, CancellationToken cancellationToken)
        {
            var masterProviderRegistry = await context.ProviderRegistries
                .AsNoTracking()
                .Where(p => p.Type == ProviderRegistryType.Master)
                .OrderByDescending(p => p.LastHeartbeatOn)
                .Select(p => new { p.Id, p.LastHeartbeatOn }).FirstOrDefaultAsync(cancellationToken);

            if (masterProviderRegistry == null)
            {
                Logger.LogWarning("Provider registry not found.");

                return true;
            }

            var threshold = DateTime.UtcNow - _masterStaleTimeout;

            if (threshold > masterProviderRegistry.LastHeartbeatOn)
            {
                Logger.LogWarning("Master is stale. Last heartbeat: '{lastHeartbeatOn}', Threshold: '{threshold}'", masterProviderRegistry.LastHeartbeatOn, threshold);

                return true;
            }

            Logger.LogDebug("Master is healthy. Last heartbeat: '{lastHeartbeatOn}', Threshold: '{threshold}'.", masterProviderRegistry.LastHeartbeatOn, threshold);

            return false;
        }

        private static void Configure(ProviderCoordinationTimedServiceOptions providerCoordinationTimedServiceOptions, TimedHostedServiceOptions timedHostedServiceOptions)
        {
            timedHostedServiceOptions.Period = TimeSpan.FromMilliseconds(providerCoordinationTimedServiceOptions.MasterCheckInterval);
            timedHostedServiceOptions.PreservePeriod = true;
        }
    }
}