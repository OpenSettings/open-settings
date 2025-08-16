using System;

namespace OpenSettings.Models.Inputs
{
    public class LoginInput
    {
        public string ReturnUrl { get; set; }

        public string ApiUrl { get; set; }

        public string Uuid { get; set; }

        public Guid? ClientId { get; set; }
    }
}