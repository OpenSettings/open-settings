using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingsDataResponse
    {
        public GetSettingsDataResponseSetting[] Settings { get; set; } = Array.Empty<GetSettingsDataResponseSetting>();
    }
}