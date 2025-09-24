using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataByIdentifierIdResponseIdentifierAppMapping
    {
        public int SortOrder { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}