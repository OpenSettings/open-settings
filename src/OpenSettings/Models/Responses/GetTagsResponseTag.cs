using System;

namespace OpenSettings.Models.Responses
{
    public class GetTagsResponseTag
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}