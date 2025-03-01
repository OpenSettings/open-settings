using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateSettingDataResponse
    {
        public Guid ClientId { get; set; }

        public UpdateSettingDataResponseSetting Setting { get; set; }
    }
}