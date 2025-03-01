using System;

namespace OpenSettings.Models.Responses
{
    public class GetGroupedAppsResponseApp
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public GetGroupedAppsResponseAppClient Client { get; set; }

        public GetGroupedAppsResponseAppGroup Group { get; set; }

        public GetGroupedAppsResponseAppTag[] Tags { get; set; } = Array.Empty<GetGroupedAppsResponseAppTag>();

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}