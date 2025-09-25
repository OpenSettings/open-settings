using Microsoft.Extensions.DependencyInjection;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    internal class DataChangeService : IDataChangeService
    {
        private readonly ITaskQueue _taskQueue;
        private readonly IServiceProvider _serviceProvider;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;
        private readonly Domains.Redis.DataContext.Context _redisContext;
        private ISubscriber _subscriber;
        private ILocalSettingService _localSettingService;

        public DataChangeService(ITaskQueueFactory taskQueueFactory, IServiceProvider serviceProvider, OpenSettingsConfiguration openSettingsConfiguration, Domains.Redis.DataContext.Context redisContext = null)
        {
            _taskQueue = taskQueueFactory.GetDataChangeQueue();
            _serviceProvider = serviceProvider;
            _openSettingsConfiguration = openSettingsConfiguration;
            _redisContext = redisContext;
        }

        public async Task NotifyChangeAsync(Guid clientId, string identifierName, Guid classComputedIdentifier, CancellationToken cancellationToken)
        {
            await _taskQueue.QueueTaskAsync(async (ct) =>
            {
                if (_openSettingsConfiguration.IsConsumerSelected)
                {
                    _localSettingService = _localSettingService ?? (_localSettingService = _serviceProvider.GetRequiredService<ILocalSettingService>());
                    await InternalNotifyChangeAsync(_localSettingService, clientId, identifierName, classComputedIdentifier, ct);
                }
                else
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var localSettingsService = scope.ServiceProvider.GetRequiredService<ILocalSettingService>();
                        await InternalNotifyChangeAsync(localSettingsService, clientId, identifierName, classComputedIdentifier, ct);
                    }
                }
            }, cancellationToken);
        }

        private async ValueTask InternalNotifyChangeAsync(ILocalSettingService localSettingService, Guid clientId, string identifierName, Guid classComputedIdentifier, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(identifierName))
            {
                return;
            }

            var identifierNameLowercase = identifierName.Trim().ToLowerInvariant();

            if (_openSettingsConfiguration.IsProviderSelected && _openSettingsConfiguration.Provider.Redis.IsActive)
            {
                var redisMessage = new RedisMessage(RedisMessageType.DataChange, _openSettingsConfiguration.InstanceDynamicId, classComputedIdentifier);

                var constructedChannelName = Helper.ConstructChannelName(_openSettingsConfiguration.Provider.Redis.Channel, clientId, identifierNameLowercase);

                await PublishAsync(constructedChannelName, redisMessage); // Todo test this with RedisMessage
            }

            if (_openSettingsConfiguration.Client.Id == clientId)
            {
                if (_openSettingsConfiguration.IdentifierNameLowercase == identifierNameLowercase)
                {
                    await localSettingService.SettingDataChangeNotifiedAsync(classComputedIdentifier, cancellationToken);
                }
                else
                {
                    await localSettingService.ReloadSettingsAsync(identifierNameLowercase, cancellationToken);
                }
            }
        }

        private async Task PublishAsync(RedisChannel channel, RedisValue message)
        {
            if (_redisContext == null)
            {
                return;
            }
            

            if (_subscriber == null)
            {
                await _redisContext.ConnectAsync();

                _subscriber = _redisContext.GetSubscriber(OpenSettingsDefaults.Names.RedisSubscriber);
            }

            await _subscriber.PublishAsync(channel, message);
        }
    }
}