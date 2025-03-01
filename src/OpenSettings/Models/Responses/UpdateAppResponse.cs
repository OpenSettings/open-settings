using System;

namespace OpenSettings.Models.Responses
{
    public class UpdateAppResponse
    {
        public string DisplayName { get; set; }

        public string ClientName { get; set; }

        public string Slug { get; set; }

        public GetGroupedAppsResponseAppGroup Group { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public UpdateAppResponseTag[] Tags { get; set; } = Array.Empty<UpdateAppResponseTag>();

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}