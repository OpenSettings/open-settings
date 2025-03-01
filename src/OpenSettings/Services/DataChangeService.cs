using Microsoft.Extensions.DependencyInjection;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.Configurations;
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
        private ILocalSettingsService _localSettingsService;

        public DataChangeService(ITaskQueueFactory taskQueueFactory, IServiceProvider serviceProvider, OpenSettingsConfiguration openSettingsConfiguration, Domains.Redis.DataContext.Context redisContext = null)
        {
            _taskQueue = taskQueueFactory.Get(Constants.TaskQueues.DataChange);
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
                    _localSettingsService = _localSettingsService ?? (_localSettingsService = _serviceProvider.GetRequiredService<ILocalSettingsService>());
                    await InternalNotifyChangeAsync(_localSettingsService, clientId, identifierName, classComputedIdentifier, ct);
                }
                else
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var localSettingsService = scope.ServiceProvider.GetRequiredService<ILocalSettingsService>();
                        await InternalNotifyChangeAsync(localSettingsService, clientId, identifierName, classComputedIdentifier, ct);
                    }
                }
            }, cancellationToken);
        }

        private async ValueTask InternalNotifyChangeAsync(ILocalSettingsService localSettingsService, Guid clientId, string identifierName, Guid classComputedIdentifier, CancellationToken cancellationToken)
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

                await PublishAsync(constructedChannelName, redisMessage);
            }

            if (_openSettingsConfiguration.Client.Id == clientId)
            {
                if (_openSettingsConfiguration.IdentifierNameLowercase == identifierNameLowercase)
                {
                    await localSettingsService.SettingDataChangeNotifiedAsync(classComputedIdentifier, cancellationToken);
                }
                else
                {
                    await localSettingsService.ReloadSettingsAsync(identifierNameLowercase, cancellationToken);
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

                _subscriber = _redisContext.GetSubscriber(Constants.RedisSubscriberName);
            }

            await _subscriber.PublishAsync(channel, message);
        }
    }
}