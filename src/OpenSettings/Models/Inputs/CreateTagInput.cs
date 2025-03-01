using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateTagInput
    {
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public SetSortOrderPosition? SetSortOrderPosition { get; set; }

        public Guid? CreatedById { get; set; }
    }
}