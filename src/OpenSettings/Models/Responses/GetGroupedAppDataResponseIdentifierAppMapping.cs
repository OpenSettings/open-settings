using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppDataResponseIdentifierAppMapping
    {
        public int SortOrder { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}