using System;

namespace OpenSettings.Models.Responses
{
    public class CopyAppSettingToResponse
    {
        public Guid ClientId { get; set; }

        public string AppSlug { get; set; }

        public CopyAppSettingToResponseIdentifier Identifier { get; set; }

        public CopyAppSettingToResponseSetting Setting { get; set; }
    }
}