using System;

namespace OpenSettings.Models.Responses
{
    public class CopySettingToResponse
    {
        public Guid ClientId { get; set; }

        public string AppSlug { get; set; }

        public CopySettingToResponseIdentifier Identifier { get; set; }

        public CopySettingToResponseSetting Setting { get; set; }
    }
}