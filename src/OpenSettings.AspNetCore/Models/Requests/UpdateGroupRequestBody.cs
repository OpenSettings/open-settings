using OpenSettings.Models;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppGroupRequestBody
    {
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public SetSortOrderPosition? SetSortOrderPosition { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}