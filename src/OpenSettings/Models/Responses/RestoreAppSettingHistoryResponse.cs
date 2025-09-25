using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreAppSettingHistoryResponse
    {
        public Guid ClientId { get; set; }

        public string IdentifierName { get; set; }

        public RestoreAppSettingHistoryResponseSetting Setting { get; set; }
    }
}