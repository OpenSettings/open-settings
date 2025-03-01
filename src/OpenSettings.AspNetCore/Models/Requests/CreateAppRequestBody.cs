using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppRequestBody
    {
        public string DisplayName { get; set; }

        public string Slug { get; set; }

        [Required]
        public CreateAppRequestBodyClient Client { get; set; }

        public CreateAppRequestBodyGroup Group { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string WikiUrl { get; set; }

        public CreateAppRequestBodyTag[] Tags { get; set; } = Array.Empty<CreateAppRequestBodyTag>();
    }
}