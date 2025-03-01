using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppGroupResponse
    {
        public UpdateAppGroupResponse(string name, string slug, int sortOrder, Guid? updatedById, DateTime updatedOn, byte[] rowVersion)
        {
            Name = name;
            Slug = slug;
            SortOrder = sortOrder;
            UpdatedById = updatedById;
            UpdatedOn = updatedOn;
            RowVersion = rowVersion ?? Array.Empty<byte>();
        }

        public string Name { get; }

        public string Slug { get; }

        public int SortOrder { get; }

        public Guid? UpdatedById { get; }

        public DateTime UpdatedOn { get; }

        public byte[] RowVersion { get; }
    }
}