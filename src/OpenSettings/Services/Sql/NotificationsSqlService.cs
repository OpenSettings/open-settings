using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Ogu.Extensions.Hosting.HostedServices;
using Ogu.Response.Abstractions;
using Ogu.Response.Json;
using OpenSettings.Domains.Sql.DataContext;
using OpenSettings.Domains.Sql.Entities;
using OpenSettings.Extensions;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Models.Responses;
using OpenSettings.Services.Interfaces;
using OpenSettings.Services.MemoryCache;
using OpenSettings.Services.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UserNotificationMappingSqlModel = OpenSettings.Domains.Sql.Entities.UserNotificationMappingSqlModel;

namespace OpenSettings.Services.Sql
{
    internal sealed class NotificationsSqlService : INotificationsSqlService
    {

        private readonly OpenSettingsDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly IOpenSettingsService _openSettingsService;
        private readonly ILocksService _locksService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ITaskQueue _taskQueue;

        public NotificationsSqlService(OpenSettingsDbContext context, OpenSettingsMemoryCache openSettingsMemoryCache, IOpenSettingsService openSettingsService, ILocksService locksService, IServiceScopeFactory serviceScopeFactory, ITaskQueueFactory taskQueueFactory)
        {
            _context = context;
            _memoryCache = openSettingsMemoryCache;
            _openSettingsService = openSettingsService;
            _locksService = locksService;
            _serviceScopeFactory = serviceScopeFactory;
            _taskQueue = taskQueueFactory.Get(Constants.TaskQueues.Notification);
        }

        public async Task<IJsonResponse> GetNotificationsAsync(GetNotificationsInput input, CancellationToken cancellationToken = default)
        {
            var availableNotifications = await GetAvailableNotificationsAsync(input.PackVersion, cancellationToken);

            var filteredUserNotifications = availableNotifications.NotificationIdToNotification.Values
                .Where(m => !input.IsExpired.HasValue || m.IsExpired == input.IsExpired)
                .Where(m => !input.Type.HasValue || m.Type == input.Type.Value)
                .Where(m => !input.Source.HasValue || m.Source == input.Source.Value)
                .OrderByDescending(m => m.CreatedOn)
                .ToArray();

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetNotificationsResponse
            {
                Notifications = filteredUserNotifications
            });
        }

        public async Task<IJsonResponse> CreateNotificationAsync(CreateNotificationInput input, CancellationToken cancellationToken = default)
        {
            if (input.Id.HasValue)
            {
                var notificationId = input.Id.Value;

                if (await _context.Notifications.AsNoTracking().AnyAsync(n => n.Id == notificationId, cancellationToken))
                {
                    return HttpStatusCode.Conflict.ToFailureJsonResponse(Errors.NotificationAlreadyExists);
                }
            }

#if !DEBUG
            if (input.Type == NotificationType.NewVersionAvailable)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse("Type not supported.");
            }
#endif
            var creatorName = string.Empty;

            if (input.CreatedById.HasValue)
            {
                creatorName = await _context.Users.AsNoTracking()
                    .Where(u => u.Id == input.CreatedById)
                    .OrderBy(u => u.Id)
                    .Select(u => u.Name)
                    .FirstOrDefaultAsync(cancellationToken);
            }

            var currentTime = DateTime.UtcNow;

            var entity = new NotificationSqlModel
            {
                Id = input.Id == Guid.Empty
                    ? Guid.NewGuid()
                    : input.Id ?? Guid.NewGuid(),
                Title = input.Title,
                Message = input.Message,
                Type = input.Type,
                Source = input.Source,
                CreatorName = creatorName,
                CreatedById = input.CreatedById,
                CreatedOn = currentTime,
            };

            _context.Notifications.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _taskQueue.QueueTaskAsync(async c =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<OpenSettingsDbContext>();

                    await DispatchNotificationsToUsersAsync(context, entity.Id, cancellationToken: c);
                }
            }, cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse(new CreateNotificationResponse
            {
                Id = entity.Id
            });
        }

        public async Task<IJsonResponse> UpdateNotificationAsync(UpdateNotificationInput input, CancellationToken cancellationToken = default)
        {
            //var notification = await _context.Notifications
            //    .AsNoTracking()
            //    .Where(n => n.Id == input.NotificationId)
            //    .OrderBy(n => n.Id)
            //    .Select()

            return null;
        }

        public async Task<IJsonResponse> DeleteNotificationAsync(DeleteNotificationInput input, CancellationToken cancellationToken = default)
        {
            var notification = await _context.Notifications
                .AsNoTracking()
                .AnyAsync(n => n.Id == input.Id, cancellationToken);

            if (!notification)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.NotificationNotFound);
            }

            _context.Notifications.Remove(new NotificationSqlModel
            {
                Id = input.Id
            });

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> GetUserNotificationsAsync(GetUserNotificationsInput input, CancellationToken cancellationToken = default)
        {
            var availableNotifications = await GetAvailableNotificationsAsync(input.PackVersion, cancellationToken);

            if (availableNotifications.NotificationIdToNotification.Count > 0)
            {
                var userNotificationMapping = await _context.Users
                    .AsNoTracking()
#if !NETSTANDARD2_0
                    .AsSplitQuery()
#endif
                    .Include(u => u.UserNotificationMappings)
                    .Where(u => u.Id == input.UserId)
                    .OrderBy(u => u.Id)
                    .Select(u => new
                    {
                        NotificationIds = new HashSet<Guid>(u.UserNotificationMappings
                            .Where(m => availableNotifications.NotificationIdToNotification.Keys.Contains(m.NotificationId))
                            .Select(m => m.NotificationId))
                    }).FirstOrDefaultAsync(cancellationToken);

                if (userNotificationMapping == null)
                {
                    return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.UserNotFound);
                }

                var currentTime = DateTime.UtcNow;

                var mappings = availableNotifications.NotificationIdToNotification
                    .Where(n => !userNotificationMapping.NotificationIds.Contains(n.Key)).Select(notification =>
                        new UserNotificationMappingSqlModel
                        {
                            UserId = input.UserId,
                            NotificationId = notification.Key,
                            CreatedOn = currentTime
                        })
                    .ToList();

                if (mappings.Count > 0)
                {
                    _context.UserNotificationMappings.AddRange(mappings);

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            var user = await _context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .ThenInclude(u => u.Notification)
                .ThenInclude(u => u.CreatedBy)
                .Where(u => u.Id == input.UserId)
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Notifications = u.UserNotificationMappings
                        .Where(m => !input.IsOpened.HasValue || m.IsOpened == input.IsOpened.Value)
                        .Where(m => !input.IsViewed.HasValue || m.IsViewed == input.IsViewed.Value)
                        .Where(m => !input.IsDismissed.HasValue || m.IsDismissed == input.IsDismissed.Value)
                        .Where(m => !input.IsExpired.HasValue || m.Notification.IsExpired == input.IsExpired)
                        .Where(m => !input.Type.HasValue || m.Notification.Type == input.Type.Value)
                        .Where(m => !input.Source.HasValue || m.Notification.Source == input.Source.Value)

                        .OrderByDescending(m => m.CreatedOn)
                        .Select(m => new GetUserNotificationsResponseNotification
                        {
                            Id = $"{m.NotificationId}",
                            Title = m.Notification.Title,
                            Message = m.Notification.Message,
                            Type = m.Notification.Type,
                            Source = m.Notification.Source,
                            Metadata = m.Notification.Metadata,
                            IsOpened = m.IsOpened,
                            IsViewed = m.IsViewed,
                            IsDismissed = m.IsDismissed,
                            IsExpired = m.Notification.IsExpired,
                            CreatedOn = m.CreatedOn,
                            CreatorName = m.Notification.CreatorName
                        }).ToList()
                }).FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.UserNotFound);
            }

            int openedCount = 0, viewedCount = 0, dismissedCount = 0, notOpenedCount = 0, notViewedCount = 0, notDismissedCount = 0;

            foreach (var notification in user.Notifications)
            {
                if (notification.IsOpened)
                {
                    openedCount++;
                }
                else
                {
                    notOpenedCount++;
                }

                if (notification.IsViewed)
                {
                    viewedCount++;
                }
                else
                {
                    notViewedCount++;
                }

                if (notification.IsDismissed)
                {
                    dismissedCount++;
                }
                else
                {
                    notDismissedCount++;
                }
            }

            return HttpStatusCode.OK.ToSuccessJsonResponse(new GetUserNotificationsResponse
            {
                NotificationCounts = new GetUserNotificationsResponseNotificationCounts
                {
                    Opened = openedCount,
                    NotOpened = notOpenedCount,
                    Viewed = viewedCount,
                    NotViewed = notViewedCount,
                    Dismissed = dismissedCount,
                    NotDismissed = notDismissedCount
                },
                Notifications = user.Notifications
            });
        }

        public async Task<IJsonResponse> MarkNotificationsAsOpenedAsync(MarkNotificationsAsOpenedInput input, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .Where(u => u.Id == input.UserId)
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    NotOpenedNotifications = u.UserNotificationMappings.Where(m => !m.IsOpened).Select(m =>
                        new UserNotificationMappingSqlModel
                        {
                            UserId = input.UserId,
                            NotificationId = m.NotificationId
                        }).ToArray()
                }).FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.UserNotFound);
            }

            var currentTime = DateTime.UtcNow;

            foreach (var notOpenedNotification in user.NotOpenedNotifications)
            {
                _context.Attach(notOpenedNotification);

                notOpenedNotification.IsOpened = true;
                notOpenedNotification.OpenedOn = currentTime;
                notOpenedNotification.UpdatedOn = currentTime;

                _context.MarkAsModified(notOpenedNotification,
                    m => m.IsOpened,
                     m => m.OpenedOn,
                    m => m.UpdatedOn);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> MarkNotificationAsViewedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .Where(u => u.Id == input.UserId)
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Notification = u.UserNotificationMappings.Where(m => m.NotificationId == input.NotificationId).Select(m =>
                        new UserNotificationMappingSqlModel
                        {
                            UserId = input.UserId,
                            NotificationId = m.NotificationId,
                            IsOpened = m.IsOpened,
                            IsViewed = m.IsViewed
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.UserNotFound);
            }

            if (user.Notification == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.NotificationNotFound);
            }

            if (user.Notification.IsViewed)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse();
            }

            _context.Attach(user.Notification);

            var properties = new List<Expression<Func<UserNotificationMappingSqlModel, object>>>
            {
                m => m.IsViewed,
                m => m.ViewedOn,
                m => m.UpdatedOn
            };

            var currentTime = DateTime.UtcNow;

            user.Notification.IsViewed = true;
            user.Notification.ViewedOn = currentTime;
            user.Notification.UpdatedOn = currentTime;

            if (!user.Notification.IsOpened)
            {
                user.Notification.IsOpened = true;
                user.Notification.OpenedOn = currentTime;

                properties.Add(m => m.IsOpened);
                properties.Add(m => m.OpenedOn);
            }

            _context.MarkAsModified(user.Notification, properties);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> MarkNotificationAsDismissedAsync(MarkNotificationAsInput input, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .Where(u => u.Id == input.UserId)
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Notification = u.UserNotificationMappings.Where(m => m.NotificationId == input.NotificationId).Select(m =>
                        new UserNotificationMappingSqlModel
                        {
                            UserId = input.UserId,
                            NotificationId = m.NotificationId,
                            IsOpened = m.IsOpened,
                            IsViewed = m.IsViewed,
                            IsDismissed = m.IsDismissed
                        }).FirstOrDefault()
                }).FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.UserNotFound);
            }

            if (user.Notification == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.NotificationNotFound);
            }

            if (user.Notification.IsDismissed)
            {
                return HttpStatusCode.OK.ToSuccessJsonResponse();
            }

            _context.Attach(user.Notification);

            var properties = new List<Expression<Func<UserNotificationMappingSqlModel, object>>>
            {
                m => m.IsDismissed,
                m => m.DismissedOn,
                m => m.UpdatedOn
            };

            var currentTime = DateTime.UtcNow;

            user.Notification.IsDismissed = true;
            user.Notification.DismissedOn = currentTime;
            user.Notification.UpdatedOn = currentTime;

            if (!user.Notification.IsOpened)
            {
                user.Notification.IsOpened = true;
                user.Notification.OpenedOn = currentTime;

                properties.Add(m => m.IsOpened);
                properties.Add(m => m.OpenedOn);
            }

            if (!user.Notification.IsViewed)
            {
                user.Notification.IsViewed = true;
                user.Notification.ViewedOn = currentTime;

                properties.Add(m => m.IsViewed);
                properties.Add(m => m.ViewedOn);
            }

            _context.MarkAsModified(user.Notification, properties);

            await _context.SaveChangesAsync(cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task<IJsonResponse> DispatchNotificationsToUsersAsync(DispatchNotificationsToUsersInput input, CancellationToken cancellationToken = default)
        {
            var notification = await _context.Notifications
                .AsNoTracking()
                .Where(n => n.Id == input.NotificationId).OrderBy(i => i.Id)
                .Select(n => new
                {
                    n.IsExpired
                }).FirstOrDefaultAsync(cancellationToken);

            if (notification == null)
            {
                return HttpStatusCode.NotFound.ToFailureJsonResponse(Errors.NotificationNotFound);
            }

            if (notification.IsExpired)
            {
                return HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.NotificationExpired);
            }

            await _taskQueue.QueueTaskAsync(async c =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<OpenSettingsDbContext>();

                    await DispatchNotificationsToUsersAsync(context, input.NotificationId, cancellationToken: c);
                }
            }, cancellationToken);

            return HttpStatusCode.OK.ToSuccessJsonResponse();
        }

        public async Task SyncOpenSettingsNotificationsAsync(CancellationToken cancellationToken)
        {
            var lockKey = nameof(SyncOpenSettingsNotificationsAsync);
            var owner = Environment.MachineName;
            var acquireLockInput = new AcquireLockInput
            {
                Key = lockKey,
                Owner = owner,
                Timeout = TimeSpan.FromMinutes(5)
            };
            var setLockExpiryTimeInput = new SetLockExpiryTimeInput
            {
                Key = lockKey,
                Owner = owner
            };

            var lockAcquired =
                await _locksService.AcquireLockAsync(acquireLockInput, cancellationToken);

            if (!lockAcquired)
            {
                return;
            }

            try
            {
                var currentTime = DateTime.UtcNow;

                var openSettingsConfigResponse = await _openSettingsService.GetConfigsDataAsync(Constants.NotificationsConfigName, cancellationToken);

                var idToOpenSettingNotification = openSettingsConfigResponse?.Data == null
                    ? new Dictionary<Guid, GetOpenSettingsNotificationsResponse>()
                    : JsonSerializer.Deserialize<GetOpenSettingsNotificationsResponse[]>(openSettingsConfigResponse.Data, Constants.JsonCaseInsensitiveOptions)
                        .DistinctBy(n => n.Id)
                        .Where(n => n.Id != Guid.Empty)
                        .ToDictionary(n => n.Id);

                var notifications = await _context.Notifications
                    .AsNoTracking()
                    .Where(n => !n.IsExpired || n.Source == NotificationSource.OpenSettings)
                    .ToDictionaryAsync(n => n.Id, cancellationToken);

                var newNotificationIdToNotification = new Dictionary<Guid, NotificationSqlModel>();

                foreach (var openSettingNotification in idToOpenSettingNotification.Values)
                {
                    var isExpired = !openSettingNotification.IsExpired && openSettingNotification.ExpiresIn.HasValue
                        ? currentTime > openSettingNotification.CreatedOn.Add(openSettingNotification.ExpiresIn.Value)
                        : openSettingNotification.IsExpired;

                    if (notifications.TryGetValue(openSettingNotification.Id, out var notification))
                    {
                        if (notification.Source != NotificationSource.OpenSettings)
                        {
                            continue;
                        }

                        _context.Notifications.Attach(notification);

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

                        // If updated, currently we're not updating the property UpdatedOn!
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

                var existingIds = await _context.Notifications.AsNoTracking()
                    .Where(n => newNotificationIdToNotification.Keys.Contains(n.Id))
                    .Select(n => n.Id)
                    .ToArrayAsync(cancellationToken);

                foreach (var existingId in existingIds)
                {
                    newNotificationIdToNotification.Remove(existingId);
                }

                _context.Notifications.AddRange(newNotificationIdToNotification.Values);

                await _context.SaveChangesAsync(cancellationToken);

                if (openSettingsConfigResponse != null)
                {
                    var cacheControl =
                        CacheControlHeaderValue.Parse(openSettingsConfigResponse.CacheControl);

                    if (cacheControl.MaxAge.HasValue)
                    {
                        setLockExpiryTimeInput.ExpiryTime =
                            DateTime.ParseExact(openSettingsConfigResponse.Expires, "R",
                                CultureInfo.InvariantCulture);

                        if (setLockExpiryTimeInput.ExpiryTime > currentTime)
                        {
                            await _locksService.SetLockExpiryTimeAsync(setLockExpiryTimeInput, cancellationToken);
                        }
                    }
                }
            }
            catch
            {
                await _locksService.ReleaseLockAsync(new ReleaseLockInput
                {
                    Key = lockKey,
                    Owner = owner
                }, CancellationToken.None);
            }
        }

        private static async Task DispatchNotificationsToUsersAsync(OpenSettingsDbContext context, Guid[] notificationIds, Guid[] userIds = null, CancellationToken cancellationToken = default)
        {
            var usersQuery = context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .Where(u => u.IsActive);

            if (userIds?.Length > 0)
            {
                usersQuery = usersQuery.Where(u => userIds.Contains(u.Id));
            }

            var users = await usersQuery.Select(u => new
            {
                u.Id,
                NotificationIds = new HashSet<Guid>(u.UserNotificationMappings.Select(m => m.NotificationId))
            }).ToArrayAsync(cancellationToken);

            var currentTime = DateTime.UtcNow;

            var newMappings = new List<UserNotificationMappingSqlModel>();

            foreach (var user in users)
            {
                newMappings.AddRange(notificationIds
                    .Where(notificationId => !user.NotificationIds.Contains(notificationId)).Select(
                        notificationId => new UserNotificationMappingSqlModel
                        {
                            UserId = user.Id,
                            NotificationId = notificationId,
                            CreatedOn = currentTime
                        }));
            }

            if (newMappings.Count > 0)
            {
                context.UserNotificationMappings.AddRange(newMappings);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        private static async Task DispatchNotificationsToUsersAsync(OpenSettingsDbContext context, Guid notificationId, Guid[] userIds = null, CancellationToken cancellationToken = default)
        {
            var usersQuery = context.Users
                .AsNoTracking()
#if !NETSTANDARD2_0
                .AsSplitQuery()
#endif
                .Include(u => u.UserNotificationMappings)
                .Where(u => u.IsActive);

            if (userIds?.Length > 0)
            {
                usersQuery = usersQuery.Where(u => userIds.Contains(u.Id));
            }

            var users = await usersQuery.Where(u => !u.UserNotificationMappings.Any(m => m.NotificationId == notificationId))
                .Select(u => new
                {
                    u.Id
                }).ToArrayAsync(cancellationToken);

            var currentTime = DateTime.UtcNow;

            foreach (var user in users)
            {
                context.UserNotificationMappings.Add(new UserNotificationMappingSqlModel
                {
                    CreatedOn = currentTime,
                    UserId = user.Id,
                    NotificationId = notificationId
                });
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        private static readonly NotificationType[] IgnoredNotificationTypes = new NotificationType[] { NotificationType.VersionMismatch, NotificationType.LicenseExpiring };

        private async Task<GetAvailableNotificationsResponse> GetAvailableNotificationsAsync(string inputPackVersion, CancellationToken cancellationToken)
        {
            if (MemoryCacheKeys.GetAvailableNotificationIds.TryGetValue(_memoryCache, out GetAvailableNotificationsResponse response))
            {
                await IncludeLicenseExpiryNotificationIfAnyAsync(response, cancellationToken);
                await IncludeVersionMismatchNotificationIfAnyAsync(response, inputPackVersion, cancellationToken);

                return response;
            }

            response = new GetAvailableNotificationsResponse();

            var currentTime = DateTime.UtcNow;

            var notifications = await _context.Notifications
                .AsNoTracking()
                .Where(n => !n.IsExpired && !IgnoredNotificationTypes.Contains(n.Type))
                .Select(n => new NotificationSqlModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Message = n.Message,
                    Type = n.Type,
                    Source = n.Source,
                    Metadata = n.Metadata,
                    ExpiresIn = n.ExpiresIn,
                    CreatedOn = n.CreatedOn,
                    CreatorName = n.CreatorName
                }).ToArrayAsync(cancellationToken);

            foreach (var notification in notifications)
            {
                if (notification.ExpiresIn.HasValue && currentTime > notification.CreatedOn.Add(notification.ExpiresIn.Value))
                {
                    _context.Attach(notification);

                    notification.IsExpired = true;
                    notification.ExpiredOn = currentTime;
                    notification.UpdatedOn = currentTime;

                    _context.MarkAsModified(notification,
                        n => n.IsExpired,
                        n => n.ExpiredOn,
                        n => n.UpdatedOn);
                }
                else
                {
                    var responseNotification = new GetNotificationsResponseNotification
                    {
                        Id = notification.Id,
                        Title = notification.Title,
                        Message = notification.Message,
                        Type = notification.Type,
                        Source = notification.Source,
                        Metadata = notification.Metadata,
                        IsExpired = notification.IsExpired,
                        CreatedOn = notification.CreatedOn,
                        CreatorName = notification.CreatorName
                    };

                    response.NotificationIdToNotification[notification.Id] = responseNotification;
                    response.UserNotifications.Add(new GetUserNotificationsResponseNotification
                    {
                        Id = $"{notification.Id}",
                        Title = notification.Title,
                        Message = notification.Message,
                        Type = notification.Type,
                        Source = notification.Source,
                        Metadata = notification.Metadata,
                        IsOpened = false,
                        IsViewed = false,
                        IsDismissed = false,
                        IsExpired = notification.IsExpired,
                        CreatedOn = notification.CreatedOn,
                        CreatorName = notification.CreatorName
                    });
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            MemoryCacheKeys.GetAvailableNotificationIds.Set(_memoryCache, response);

            await IncludeLicenseExpiryNotificationIfAnyAsync(response, cancellationToken);
            await IncludeVersionMismatchNotificationIfAnyAsync(response, inputPackVersion, cancellationToken);

            return response;
        }

        private async Task IncludeLicenseExpiryNotificationIfAnyAsync(GetAvailableNotificationsResponse response, CancellationToken cancellationToken)
        {
            var currentLicense = LicenseProvider.Instance.CurrentLicense;

            if (!currentLicense.ExpiryDate.HasValue || currentLicense.ExpiryDate.Value.Date > DateTime.UtcNow.Date.AddDays(5))
            {
                return;
            }

            var licenseExpiryNotification = await GetLicenseExpiryNotificationAsync(currentLicense, cancellationToken);

            if (licenseExpiryNotification == null)
            {
                return;
            }

            response.NotificationIdToNotification[licenseExpiryNotification.NotificationId] = licenseExpiryNotification.Notification;
            response.UserNotifications.Add(new GetUserNotificationsResponseNotification
            {
                Id = $"{licenseExpiryNotification.Notification.Id}",
                Title = licenseExpiryNotification.Notification.Title,
                Message = licenseExpiryNotification.Notification.Message,
                Type = licenseExpiryNotification.Notification.Type,
                Source = licenseExpiryNotification.Notification.Source,
                Metadata = licenseExpiryNotification.Notification.Metadata,
                IsOpened = false,
                IsViewed = false,
                IsDismissed = false,
                IsExpired = false,
                CreatedOn = licenseExpiryNotification.Notification.CreatedOn,
                CreatorName = licenseExpiryNotification.Notification.CreatorName
            });
        }

        private async Task<InternalNotificationResponse> GetLicenseExpiryNotificationAsync(License currentLicense, CancellationToken cancellationToken)
        {
            var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;
            var currentTime = DateTime.UtcNow;
            var currentDate = currentTime.Date;
            var notificationId = Helper.ComputeIdentifier($"license-expire-{currentLicense.ReferenceId}-{currentDate.ToString("d", CultureInfo.InvariantCulture)}");

            var response = new GetNotificationsResponseNotification
            {
                Id = notificationId,
                Title = "License Expiring Soon",
                Message = $"Your {currentLicense.Edition} Edition license (Ref ID: {currentLicense.ReferenceId}) will expire on {currentLicense.ExpiryDate.Value:U}. Please renew in time to avoid any service disruptions.",
                Type = NotificationType.LicenseExpiring,
                Source = NotificationSource.System,
                Metadata = new Dictionary<string, object>(),
                CreatedOn = currentTime,
                CreatorName = openSettingsAssemblyInfo.Name
            };

            var notification = await _context.Notifications.AsNoTracking().Where(n => n.Id == notificationId).OrderBy(n => n.Id).Select(n => new NotificationSqlModel
            {
                Id = notificationId,
                IsExpired = n.IsExpired
            }).FirstOrDefaultAsync(cancellationToken);

            if (notification == null)
            {
                _context.Notifications.Add(new NotificationSqlModel
                {
                    Id = notificationId,
                    Title = response.Title,
                    Message = response.Message,
                    Type = response.Type,
                    Source = response.Source,
                    Metadata = response.Metadata,
                    ExpiresIn = null,
                    CreatedOn = currentTime,
                    CreatorName = openSettingsAssemblyInfo.Name
                });

                await _context.SaveChangesAsync(cancellationToken);

                return new InternalNotificationResponse
                {
                    NotificationId = notificationId,
                    Notification = response
                };
            }

            if (!notification.IsExpired)
            {
                return new InternalNotificationResponse
                {
                    NotificationId = notificationId,
                    Notification = response
                };
            }

            _context.Notifications.Attach(notification);

            notification.IsExpired = false;
            notification.ExpiredOn = null;
            notification.UpdatedOn = currentTime;

            _context.MarkAsModified(notification,
                n => n.IsExpired,
                n => n.ExpiredOn,
                n => n.UpdatedOn);

            await _context.SaveChangesAsync(cancellationToken);

            return new InternalNotificationResponse
            {
                NotificationId = notificationId,
                Notification = response
            };
        }

        private async Task IncludeVersionMismatchNotificationIfAnyAsync(GetAvailableNotificationsResponse response, string inputPackVersion, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(inputPackVersion))
            {
                return;
            }

            var versionMismatchNotification = await GetVersionMismatchNotificationAsync(inputPackVersion, cancellationToken);

            if (versionMismatchNotification == null)
            {
                return;
            }

            response.NotificationIdToNotification[versionMismatchNotification.NotificationId] = versionMismatchNotification.Notification;
            response.UserNotifications.Add(new GetUserNotificationsResponseNotification
            {
                Id = $"{versionMismatchNotification.Notification.Id}",
                Title = versionMismatchNotification.Notification.Title,
                Message = versionMismatchNotification.Notification.Message,
                Type = versionMismatchNotification.Notification.Type,
                Source = versionMismatchNotification.Notification.Source,
                Metadata = versionMismatchNotification.Notification.Metadata,
                IsOpened = false,
                IsViewed = false,
                IsDismissed = false,
                IsExpired = false,
                CreatedOn = versionMismatchNotification.Notification.CreatedOn,
                CreatorName = versionMismatchNotification.Notification.CreatorName
            });
        }
        private async Task<InternalNotificationResponse> GetVersionMismatchNotificationAsync(string inputPackVersion, CancellationToken cancellationToken)
        {
            var openSettingsAssemblyInfo = OpenSettingsAssemblyInfo.Instance;

            if (openSettingsAssemblyInfo.Version == inputPackVersion)
            {
                return null;
            }

            var notificationId = Helper.ComputeIdentifier($"version-mismatch-{openSettingsAssemblyInfo.Version}-{inputPackVersion}");
            var currentTime = DateTime.UtcNow;

            var response = new GetNotificationsResponseNotification
            {
                Id = notificationId,
                Title = "Version Mismatch Detected",
                Message = $"Provider's OpenSettings pack version (v{openSettingsAssemblyInfo.Version}) is different from the current pack version (v{inputPackVersion}). Some UI features might be broken!",
                Type = NotificationType.VersionMismatch,
                Source = NotificationSource.System,
                Metadata = new Dictionary<string, object>
                {
                    { "version", openSettingsAssemblyInfo.Version }
                },
                CreatedOn = currentTime,
                CreatorName = openSettingsAssemblyInfo.Name
            };

            var notification = await _context.Notifications.AsNoTracking().Where(n => n.Id == notificationId).OrderBy(n => n.Id).Select(n => new NotificationSqlModel
            {
                Id = notificationId,
                IsExpired = n.IsExpired
            }).FirstOrDefaultAsync(cancellationToken);

            if (notification == null)
            {
                _context.Notifications.Add(new NotificationSqlModel
                {
                    Id = notificationId,
                    Title = response.Title,
                    Message = response.Message,
                    Type = response.Type,
                    Source = response.Source,
                    Metadata = response.Metadata,
                    ExpiresIn = null,
                    CreatedOn = currentTime,
                    CreatorName = openSettingsAssemblyInfo.Name
                });

                await _context.SaveChangesAsync(cancellationToken);

                return new InternalNotificationResponse
                {
                    NotificationId = notificationId,
                    Notification = response
                };
            }

            if (!notification.IsExpired)
            {
                return new InternalNotificationResponse
                {
                    NotificationId = notificationId,
                    Notification = response
                };
            }

            _context.Notifications.Attach(notification);

            notification.IsExpired = false;
            notification.ExpiredOn = null;
            notification.UpdatedOn = currentTime;

            _context.MarkAsModified(notification,
                n => n.IsExpired,
                n => n.ExpiredOn,
                n => n.UpdatedOn);

            await _context.SaveChangesAsync(cancellationToken);

            return new InternalNotificationResponse
            {
                NotificationId = notificationId,
                Notification = response
            };
        }
    }
}