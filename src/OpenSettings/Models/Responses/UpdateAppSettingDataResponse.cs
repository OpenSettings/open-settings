using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppSettingDataResponse
    {
        public Guid ClientId { get; set; }

        public UpdateAppSettingDataResponseSetting Setting { get; set; }
    }
}