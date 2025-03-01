using System;

namespace OpenSettings.Models.Responses
{
    public class GetOrCreateUserResponse
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string Initials { get; set; }

        public bool IsActive { get; set; }

        public bool IsNewlyCreated { get; set; }
    }
}