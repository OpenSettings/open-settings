using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateUserInput
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public Guid? CreatedById { get; set; }
    }
}