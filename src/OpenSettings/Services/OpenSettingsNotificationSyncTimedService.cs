using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ogu.Extensions.Hosting.HostedServices;
using OpenSettings.AspNetCore.Models;
using OpenSettings.Configurations;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Models;
using OpenSettings.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.Services
{
    /// <summary>
    /// A timed service that synchronizes OpenSettings notifications with the local database.
    /// </summary>
    internal sealed class OpenSettingsNotificationSyncTimedService : TimedHostedService, IOpenSettingsNotificationSyncTimedService
    {
        private readonly IOpenSettingsService _openSettingsService;
        private readonly OpenSettingsConfiguration _openSettingsConfiguration;

        public OpenSettingsNotificationSyncTimedService(
            ILogger<OpenSettingsNotificationSyncTimedService> logger, 
            IOptions<OpenSettingsNotificationSyncTimedServiceOptions> openSettingsNotificationSyncTimedServiceOptions,
            IOpenSettingsService openSettingsService, 
            OpenSettingsConfiguration openSettingsConfiguration) : base(logger, nameof(OpenSettingsNotificationSyncTimedService),
            timedHostedServiceOptions => Configure(openSettingsNotificationSyncTimedServiceOptions.Value, timedHostedServiceOptions))
        {
            _openSettingsService = openSettingsService;
            _openSettingsConfiguration = openSettingsConfiguration;
        }

        protected override async ValueTask DoWorkAsync(CancellationToken cancellationToken)
        {
            var response = await _openSettingsService.GetNotificationsAsync(cancellationToken);

            UpdatePeriod(response.CacheControl);

            if (response.IdToNotification.Count == 0)
            {
                return;
            }

            using (var context = OpenSettingsDbContext.GetInstance(_openSettingsConfiguration.Provider))
            {
                var notifications = await context.Notifications
                    .AsNoTracking()
                    .Where(n => n.Source == NotificationSource.OpenSettings)
                    .ToDictionaryAsync(n => n.Id, cancellationToken);

                var newNotificationIdToNotification = new Dictionary<Guid, NotificationSqlModel>();

                var currentTime = DateTime.UtcNow;

                foreach (var openSettingNotification in response.IdToNotification.Values)
                {
                    var isExpired = !openSettingNotification.IsExpired && openSettingNotification.ExpiresIn.HasValue
                        ? currentTime > openSettingNotification.CreatedOn.Add(openSettingNotification.ExpiresIn.Value)
                        : openSettingNotification.IsExpired;

                    if (notifications.TryGetValue(openSettingNotification.Id, out var notification))
                    {
                        context.Notifications.Attach(notification);

                        var expiredOn = !notification.IsExpired && isExpired
                            ? (DateTime?)currentTime
                            : notification.ExpiredOn;

                        notification.Title = openSettingNotification.Title;
                        notification.Message = openSettingNotification.Message;
                        notification.Type = openSettingNotification.Type;
                        notification.Metadata = openSettingNotification.Metadata;
                        notification.CreatedOn = openSettingNotification.CreatedOn;
                        notification.ExpiresIn = openSettingNotification.ExpiresIn;
                        notification.IsExpired = isExpired;
                        notification.ExpiredOn = expiredOn;
                        notification.CreatorName = openSettingNotification.CreatedBy;

                        if (context.ChangeTracker.HasChanges())
                        {
                            notification.UpdatedOn = currentTime;
                        }
                    }
                    else
                    {
                        newNotificationIdToNotification[openSettingNotification.Id] = new NotificationSqlModel
                        {
                            Id = openSettingNotification.Id,
                            Title = openSettingNotification.Title,
                            Message = openSettingNotification.Message,
                            Type = openSettingNotification.Type,
                            Source = NotificationSource.OpenSettings,
                            Metadata = openSettingNotification.Metadata,
                            CreatedOn = openSettingNotification.CreatedOn,
                            ExpiresIn = openSettingNotification.ExpiresIn,
                            IsExpired = isExpired,
                            ExpiredOn = isExpired ? (DateTime?)currentTime : null,
                            CreatorName = openSettingNotification.CreatedBy
                        };
                    }
                }

                var existingIds = await context.Notifications.AsNoTracking()
                    .Where(n => newNotificationIdToNotification.Keys.Contains(n.Id))
                    .Select(n => n.Id)
                    .ToArrayAsync(cancellationToken);

                foreach (var existingId in existingIds)
                {
                    newNotificationIdToNotification.Remove(existingId);
                }

                context.Notifications.AddRange(newNotificationIdToNotification.Values);

                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public void UpdatePeriod(string cacheControl)
        {
            if (cacheControl == null)
            {
                return;
            }

            var cacheControlHeaderValue = CacheControlHeaderValue.Parse(cacheControl);

            if (cacheControlHeaderValue.MaxAge.HasValue)
            {
                var periodInSeconds = Math.Max(cacheControlHeaderValue.MaxAge.Value.TotalSeconds, 10);

                UpdateOptions(opts =>
                {
                    opts.Period = TimeSpan.FromSeconds(periodInSeconds);
                });
            }
        }

        private static void Configure(OpenSettingsNotificationSyncTimedServiceOptions openSettingsNotificationSyncTimedServiceOptions, TimedHostedServiceOptions timedHostedServiceOptions)
        {
            timedHostedServiceOptions.PreservePeriod = openSettingsNotificationSyncTimedServiceOptions.PreservePeriod;
            timedHostedServiceOptions.TaskTimeout = openSettingsNotificationSyncTimedServiceOptions.TaskTimeout;
        }
    }
}