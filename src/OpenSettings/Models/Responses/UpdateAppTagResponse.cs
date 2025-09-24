using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppTagResponse
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public int SortOrder { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime UpdatedOn { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}