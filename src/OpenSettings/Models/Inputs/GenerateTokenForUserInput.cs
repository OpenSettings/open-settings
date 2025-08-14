using System;

namespace OpenSettings.Models.Inputs
{
    public class GenerateTokenForUserInput
    {
        public Guid UserId { get; set; }

        public string DisplayName { get; set; }

        public string UserInitials { get; set; }

        public string Audience { get; set; }
    }
}