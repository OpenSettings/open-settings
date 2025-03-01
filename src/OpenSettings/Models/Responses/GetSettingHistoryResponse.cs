using System;

namespace OpenSettings.Models.Responses
{
    public class GetSettingHistoryResponse
    {
        public string Data { get; set; }

        public string Version { get; set; }

        public string Slug { get; set; }

        public string SettingId { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid? RestoredById { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}