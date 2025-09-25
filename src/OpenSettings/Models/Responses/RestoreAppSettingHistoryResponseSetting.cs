using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreAppSettingHistoryResponseSetting
    {
        public Guid ComputedIdentifier { get; set; }

        public RestoreAppSettingHistoryResponseSettingInfo Restored { get; set; }

        public RestoreAppSettingHistoryResponseSettingInfo Archived { get; set; }
    }
}