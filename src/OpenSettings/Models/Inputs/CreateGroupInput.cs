using System;
using System.Text.Json.Serialization;

namespace OpenSettings.Models.Inputs
{
    public class CreateGroupInput
    {
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public SetSortOrderPosition? SetSortOrderPosition { get; set; }

        [JsonIgnore]
        public Guid? CreatedById { get; set; }
    }
}