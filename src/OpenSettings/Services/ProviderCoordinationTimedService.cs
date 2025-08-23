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
using System.Collections.Generic;
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
        public static Guid ProviderRegistryId { get; } = Guid.NewGuid();

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

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderCoordinationTimedService"/> class.
        /// </summary>
        /// <param name="providerCoordinationTimedServiceOptions">The provider coordination timed service options.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="openSettingsConfiguration">The OpenSettings configuration.</param>
        public ProviderCoordinationTimedService(
            IOptions<ProviderCoordinationTimedServiceOptions> providerCoordinationTimedServiceOptions,
            IServiceProvider serviceProvider, OpenSettingsConfiguration openSettingsConfiguration)
            : base(openSettingsConfiguration.LoggerFactory.CreateLogger<ProviderCoordinationTimedService>(),
                nameof(ProviderCoordinationTimedService),
                timedHostedServiceOpts => Configure(providerCoordinationTimedServiceOptions.Value, timedHostedServiceOpts))
        {
            _serviceProvider = serviceProvider;

            var providerCoordinationTimedServiceOptsValue = providerCoordinationTimedServiceOptions.Value;
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
                        .Where(p => p.Id == ProviderRegistryId)
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
                                    .AnyAsync(p => p.Type == ProviderRegistryType.Master && p.Id != ProviderRegistryId && p.LastHeartbeatOn >= threshold, cancellationToken);

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

                            Logs.BecameMasterSuccessfully(Logger, ProviderRegistryId, _openSettingsConfiguration.Client.Id, null);

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

            var failedServices= new List<string>(_masterProviderServices.Length);
            var succeedServices = new List<string>(_masterProviderServices.Length);

            var tasksForStart = _masterProviderServices.Select(service => service.StartAsync(cancellationToken)
                .ContinueWith(task =>
                {
                    var serviceName = service.GetType().Name;

                    if (task.IsFaulted)
                    {
                        failedServices.Add(serviceName);
                    }
                    else
                    {
                        succeedServices.Add(serviceName);
                    }
                }, cancellationToken));

            await Task.WhenAll(tasksForStart);

            if (failedServices.Count > 0)
            {
                Logs.FailedToStartServices(Logger, string.Join(OpenSettingsDefaults.Format.CommaWithSpace, failedServices), null);
            }

            if (succeedServices.Count > 0)
            {
                Logs.ServicesStartedSuccessfully(Logger, string.Join(OpenSettingsDefaults.Format.CommaWithSpace, succeedServices), null);
            }
        }

        private async Task StopMasterProviderServices(CancellationToken cancellationToken)
        {
            if (_masterProviderServices == null)
            {
                return;
            }

            var failedServices = new List<string>(_masterProviderServices.Length);
            var succeedServices = new List<string>(_masterProviderServices.Length);

            var tasksForStop = _masterProviderServices.Select(service => service.StopAsync(cancellationToken)
                .ContinueWith(task =>
                {
                    var serviceName = service.GetType().Name;

                    if (task.IsFaulted)
                    {
                        failedServices.Add(serviceName);
                    }
                    else
                    {
                        succeedServices.Add(serviceName);
                    }
                }, cancellationToken));

            await Task.WhenAll(tasksForStop);

            if (failedServices.Count > 0)
            {
                Logs.FailedToStopServices(Logger, string.Join(OpenSettingsDefaults.Format.Comma, failedServices), null);
            }

            if (succeedServices.Count > 0)
            {
                Logs.ServiceStoppedSuccessfully(Logger, string.Join(OpenSettingsDefaults.Format.Comma, succeedServices), null);
            }
        }

        private async Task RegisterProviderAsync(OpenSettingsDbContext context, CancellationToken cancellationToken)
        {
            var clientId = _openSettingsConfiguration.Client.Id;
            var clientIdLowercase = $"{clientId}".ToLowerInvariant();
            var currentTime = DateTime.UtcNow;

            var providerRegistry = new ProviderRegistrySqlModel
            {
                Id = ProviderRegistryId,
                Type = ProviderRegistryType.Slave,
                ClientId = clientId,
                ClientIdLowercase = clientIdLowercase,
                InstanceDynamicId = _openSettingsConfiguration.InstanceDynamicId,
                Scheme = ProviderRegistryScheme.Unset,
                Region = string.Empty,
                Version = _openSettingsConfiguration.Client.Version,
                PackVersion = OpenSettingsAssemblyInfo.Instance.PackInfo.Version,
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
            var providerRegistry = new ProviderRegistrySqlModel { Id = ProviderRegistryId };

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
                Id = ProviderRegistryId,
                Type = ProviderRegistryType.Master,
                LastHeartbeatOn = DateTime.UtcNow
            };

            var entry = context.ProviderRegistries.Attach(masterProviderRegistry);

            entry.Property(p => p.Type).IsModified = true;
            entry.Property(p => p.LastHeartbeatOn).IsModified = true;

            var oldMasterProviders = await context.ProviderRegistries.AsNoTracking()
                .Where(p => p.Id != ProviderRegistryId && p.Type == ProviderRegistryType.Master)
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
                Logs.MasterTypeProviderNotFound(Logger, null);

                return true;
            }

            var threshold = DateTime.UtcNow - _masterStaleTimeout;

            if (threshold > masterProviderRegistry.LastHeartbeatOn)
            {
                Logs.MasterStale(Logger, masterProviderRegistry.LastHeartbeatOn, threshold, null);

                return true;
            }
            
            Logs.MasterHealthy(Logger, masterProviderRegistry.LastHeartbeatOn, threshold, null);

            return false;
        }

        private static void Configure(ProviderCoordinationTimedServiceOptions providerCoordinationTimedServiceOptions, TimedHostedServiceOptions timedHostedServiceOptions)
        {
            timedHostedServiceOptions.Period = TimeSpan.FromMilliseconds(providerCoordinationTimedServiceOptions.MasterCheckInterval);
            timedHostedServiceOptions.PreservePeriod = true;
            timedHostedServiceOptions.LogOptions.LogWhenTaskStarted = false;
            timedHostedServiceOptions.LogOptions.LogWhenTaskCompleted = false;
        }

        private static class Logs
        {
            public static readonly Action<ILogger, Exception> MasterTypeProviderNotFound =
                LoggerMessage.Define(LogLevel.Warning,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.MasterTypeProviderNotFound,
                    "The master type provider could not be found.");

            public static readonly Action<ILogger, DateTime, DateTime, Exception> MasterStale =
                LoggerMessage.Define<DateTime, DateTime>(LogLevel.Warning,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.MasterStale,
                    "Master is stale. Last heartbeat: '{lastHeartbeatOn}', Threshold: '{threshold}'");

            public static readonly Action<ILogger, DateTime, DateTime, Exception> MasterHealthy =
                LoggerMessage.Define<DateTime, DateTime>(LogLevel.Debug,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.MasterHealthy,
                    "Master is healthy. Last heartbeat: '{lastHeartbeatOn}', Threshold: '{threshold}'.");

            public static readonly Action<ILogger, string, Exception> FailedToStartServices =
                LoggerMessage.Define<string>(LogLevel.Error,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.FailedToStartServices,
                    "Failed to start services: '{services}'.");

            public static readonly Action<ILogger, string, Exception> FailedToStopServices =
                LoggerMessage.Define<string>(LogLevel.Error,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.FailedToStopServices,
                    "Failed to stop services: '{services}'");

            public static readonly Action<ILogger, string, Exception> ServicesStartedSuccessfully
                = LoggerMessage.Define<string>(LogLevel.Information,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.ServicesStartedSuccessfully,
                    "Services started successfully: '{services}'.");

            public static readonly Action<ILogger, string, Exception> ServiceStoppedSuccessfully =
                LoggerMessage.Define<string>(LogLevel.Information,
                    OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.ServicesStoppedSuccessfully,
                    "Services stopped successfully: '{services}'");

            public static readonly Action<ILogger, Guid, Guid, Exception> BecameMasterSuccessfully = LoggerMessage.Define<Guid, Guid>(LogLevel.Information,
                OpenSettingsDefaults.EventIds.ProviderCoordinationTimedService.BecameMasterSuccessfully,
                "ProviderRegistryId '{providerRegistryId}' for ClientId '{clientId}' successfully became master.");
        }
    }
}