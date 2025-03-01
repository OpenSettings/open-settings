using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppIdentifierMappingSortOrderResponse
    {
        public int SortOrder { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}