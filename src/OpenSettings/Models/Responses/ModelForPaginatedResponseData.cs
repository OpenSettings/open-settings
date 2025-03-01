using System;

namespace OpenSettings.Models.Responses
{
    public class ModelForPaginatedResponseData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int SortOrder { get; set; }

        public int MappingsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}