using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateIdentifierResponse
    {
        public UpdateIdentifierResponse()
        {
        }

        public UpdateIdentifierResponse(string name, string slug, int sortOrder, Guid? updatedById, DateTime updatedOn, byte[] rowVersion)
        {
            Name = name;
            Slug = slug;
            SortOrder = sortOrder;
            UpdatedById = updatedById;
            UpdatedOn = updatedOn;
            RowVersion = rowVersion ?? Array.Empty<byte>();
        }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int SortOrder { get; set; }

        public Guid? UpdatedById { get; set; }

        public DateTime UpdatedOn { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}