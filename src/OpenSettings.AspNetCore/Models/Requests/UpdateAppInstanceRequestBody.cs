using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppInstanceRequestBody
    {
        public Guid ClientSecret { get; set; }

        public string InstanceName { get; set; }

        public string IdentifierName { get; set; }

        public string[] Urls { get; set; } = Array.Empty<string>();

        public bool IsActive { get; set; }
    }
}