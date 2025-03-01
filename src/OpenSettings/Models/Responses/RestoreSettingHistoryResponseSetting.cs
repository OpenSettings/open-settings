using System;

namespace OpenSettings.Models.Responses
{
    public class RestoreSettingHistoryResponseSetting
    {
        public string IdentifierName { get; set; }

        public Guid ComputedIdentifier { get; set; }

        public string CurrentVersion { get; set; }

        public string PreviousVersion { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}