using System;
using System.Text.Json.Serialization;

namespace OpenSettings.Models.Inputs
{
    public class UpdateGroupInput
    {
        [JsonIgnore]
        public string GroupId { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public SetSortOrderPosition? SetSortOrderPosition { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        [JsonIgnore]
        public Guid? UpdatedById { get; set; }
    }
}