using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppSettingsDataResponse
    {
        public GetAppSettingsDataResponseSetting[] Settings { get; set; } = Array.Empty<GetAppSettingsDataResponseSetting>();
    }
}