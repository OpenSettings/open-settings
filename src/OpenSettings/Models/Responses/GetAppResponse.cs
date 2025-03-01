using System;

namespace OpenSettings.Models.Responses
{
    public class GetAppResponse
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public GetAppResponseClient Client { get; set; }

        public GetAppResponseGroup Group { get; set; }

        public GetAppResponseTag[] Tags { get; set; } = Array.Empty<GetAppResponseTag>();

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}