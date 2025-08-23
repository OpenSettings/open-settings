using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Helpers;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services.Redis
{
    internal sealed class OpenSettingsRedisHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly string _instanceDynamicId;
        private readonly ISubscriber _subscriber;
        private readonly RedisChannel _channel;
        private readonly ILocalSettingsService _localSettingsService;

        public OpenSettingsRedisHostedService(
            OpenSettingsConfiguration openSettingsConfiguration,
            ILocalSettingsService localSettingsService,
            ProviderInfo providerInfo,
            Domains.Redis.DataContext.Context redisContext)
        {
            _logger = openSettingsConfiguration.LoggerFactory.CreateLogger<OpenSettingsRedisHostedService>();
            _instanceDynamicId = openSettingsConfiguration.InstanceDynamicId;
            _localSettingsService = localSettingsService;
            _channel = Helper.ConstructChannelName(providerInfo.Redis.Channel, openSettingsConfiguration.Client.Id, openSettingsConfiguration.IdentifierNameLowercase);
            _subscriber = redisContext.GetSubscriber(OpenSettingsDefaults.Names.RedisSubscriber);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                var isFailure = true;

                while (isFailure)
                {
                    try
                    {
                        await _subscriber.SubscribeAsync(_channel, MessageHandler());

                        isFailure = false;
                    }
                    catch (Exception ex)
                    {
                        Logs.RedisSubscriptionFailed(_logger, _channel, ex);

                        await Task.Delay(5000, cancellationToken);
                    }
                }
            }, cancellationToken);
            

            return Task.CompletedTask ;
        }

        public Task StopAsync(CancellationToken cancellationToken) => _subscriber.UnsubscribeAsync(_channel);

        public Action<RedisChannel, RedisValue> MessageHandler()
        {
            return (channel, value) =>
                Task.Run(async () =>
                {
                    var redisMessage = value.ToRedisMessage();

                    // If message comes from the same instance, simply discard it or data type isn't JsonElement which won't be the case.
                    if (_instanceDynamicId == redisMessage.InstanceDynamicId || !(redisMessage.Data is JsonElement jsonElement))
                    {
                        return;
                    }

                    switch (redisMessage.MessageType)
                    {
                        case RedisMessageType.DataChange:
                            Logs.DataChangeNotified(_logger, null);

                            var classComputedIdentifier = Guid.Parse(jsonElement.GetString());

                            await _localSettingsService.SettingDataChangeNotifiedAsync(classComputedIdentifier, CancellationToken.None).ConfigureAwait(false);

                            break;
                    }
                });
        }

        private static class Logs
        {
            public static readonly Action<ILogger, Exception> DataChangeNotified = LoggerMessage.Define(LogLevel.Information, OpenSettingsDefaults.EventIds.OpenSettingsRedisHostedService.DataChangeNotified, "Data change being notified!.");

            public static readonly Action<ILogger, string, Exception> RedisSubscriptionFailed = LoggerMessage.Define<string>(LogLevel.Error, OpenSettingsDefaults.EventIds.OpenSettingsRedisHostedService.RedisSubscriptionFailed, "Redis subscription to channel: '{channel}' failed!.");
        }
    }
}