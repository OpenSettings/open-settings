using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppRequestBody
    {
        public string DisplayName { get; set; }

        public string Slug { get; set; }

        public UpdateAppRequestBodyClient Client { get; set; }

        public UpdateAppRequestBodyGroup Group { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public UpdateAppRequestBodyTag[] Tags { get; set; } = Array.Empty<UpdateAppRequestBodyTag>();

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}