using System;

namespace OpenSettings.Models.Responses
{
    public class CopySettingToResponseSetting
    {
        public string Id { get; set; }

        public string ClassId { get; set; }

        public Guid ComputedIdentifier { get; set; }
    }
}