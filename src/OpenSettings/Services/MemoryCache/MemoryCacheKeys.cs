using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenSettings.Services.MemoryCache
{
    public static class MemoryCacheKeys
    {
        public static CacheModel GetAvailableNotificationIds = new CacheModel("nss:gania", TimeSpan.FromMinutes(5));

        public static CacheModel OpenSettingsSpaMiddlewareHtml = new CacheModel("ossm:html");



        public static CacheModel GetAllAppsAsync = new CacheModel(nameof(GetAllAppsAsync), TimeSpan.FromHours(1));

        public static CacheModel IsAppRegisteredAsync(Guid clientId, Guid clientSecret)
        {
            return new CacheModel(new object[] { nameof(IsAppRegisteredAsync), clientId, clientSecret }, TimeSpan.FromMinutes(5));
        }

        public static CacheModel GetAppByClientIdAsync(Guid clientId)
        {
            return new CacheModel(new object[] { nameof(GetAppByClientIdAsync), clientId }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetGroupedAppSettingsAsync(Guid? clientId = null)
        {
            return new CacheModel(new object[] { nameof(GetGroupedAppSettingsAsync), clientId }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetAppSettingsAsync(Guid? clientId = null, string identifier = null, string ids = null)
        {
            return new CacheModel(new object[] { nameof(GetAppSettingsAsync), clientId, identifier, ids }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetAppSettingAsync(Guid? clientId = null, object settingId = null)
        {
            return new CacheModel(new object[] { nameof(GetAppSettingAsync), clientId, settingId}, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetAppSettingHistoriesAsync(Guid? clientId = null, object settingId = null)
        {
            return new CacheModel(new object[] { nameof(GetAppSettingHistoriesAsync), clientId, settingId }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetAppSettingHistoryDataAsync(Guid? clientId = null, object settingId = null, string historyId = null)
        {
            return new CacheModel(new object[] { nameof(GetAppSettingHistoryDataAsync), clientId, settingId, historyId }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel GetSettingsLastUpdatedComputedIdentifiersAsync(Guid? clientId = null, string identifierId = null, DateTime? lastUpdatedOn = null)
        {
            return new CacheModel(new object[] { nameof(GetSettingsLastUpdatedComputedIdentifiersAsync), clientId, identifierId, lastUpdatedOn}, TimeSpan.FromMinutes(5));
        }

        public static CacheModel ReadAsync(Guid? clientId = null, string identifierId = null, HashSet<Guid> classComputedIdentifiers = null, bool? hasStoreSettingsInItsOwnFileAttribute = null)
        {
            var keyParts = new object[]
                { nameof(ReadAsync), clientId, identifierId }.AsEnumerable();

            if (classComputedIdentifiers != null)
            {
                keyParts = keyParts.Concat(classComputedIdentifiers.Cast<object>());
            }

            return new CacheModel(keyParts.Append(hasStoreSettingsInItsOwnFileAttribute), TimeSpan.FromMinutes(5));
        }

        public static CacheModel GetAppInstancesAsync(Guid? clientId = null, string identifierId = null)
        {
            return new CacheModel(new object[] { nameof(GetAppInstancesAsync), clientId, identifierId }, TimeSpan.FromMinutes(30));
        }

        public static CacheModel SyncDataAsync(Guid clientId,
            string identifierId = null, string clientName = null, Guid? clientSecret = null, SyncAppDataInputInstance instance = null, ICollection<SyncAppDataInputSetting> appSettings = null )
        {
            var keyParts = new object[]
                { nameof(SyncDataAsync), clientId, identifierId, clientName, clientSecret, instance?.InstanceName }.AsEnumerable();

            if (appSettings != null)
            {
                keyParts = keyParts.Concat(appSettings.OrderBy(a => a.SettingClass.Name)
                    .Select(s => $"{s.HashCode}:{s.SettingClass.HashCode}"));
            }

            return new CacheModel(keyParts, TimeSpan.FromMinutes(5));
        }
    }
}