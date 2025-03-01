using System;

namespace OpenSettings.Models.Responses
{
    public class FetchAppDataResponse
    {
        public DateTime LastUpdatedOn { get; set; }

        public FetchAppDataResponseSetting[] Settings { get; set; } = Array.Empty<FetchAppDataResponseSetting>();
    }
}