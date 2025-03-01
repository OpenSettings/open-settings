using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateAppInput
    {
        public string DisplayName { get; set; }

        public string Slug { get; set; }

        public CreateAppInputClient Client { get; set; }

        public CreateAppInputGroup Group { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public CreateAppInputTag[] Tags { get; set; } = Array.Empty<CreateAppInputTag>();

        public Guid? CreatedById { get; set; }
    }
}