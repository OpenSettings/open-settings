using System;

namespace OpenSettings.Models.Inputs
{
    public class LoginInput
    {
        public string ReturnUrl { get; set; }

        public string ApiUrl { get; set; }

        public Guid StateId { get; set; }

        public Guid? ClientId { get; set; }
    }
}