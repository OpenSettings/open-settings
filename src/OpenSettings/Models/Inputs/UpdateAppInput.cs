using System;

namespace OpenSettings.Models.Inputs
{
    public class UpdateAppInput
    {
        public string AppId { get; set; }

        public string DisplayName { get; set; }

        public string ClientName { get; set; }

        public string Slug { get; set; }

        public UpdateAppInputGroup Group { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public UpdateAppInputTag[] Tags { get; set; } = Array.Empty<UpdateAppInputTag>();

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public Guid? UpdatedById { get; set; }
    }
}