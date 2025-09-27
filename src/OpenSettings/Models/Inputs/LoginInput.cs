using System;

namespace OpenSettings.Models.Inputs
{
    public class LoginInput
    {
        public string ReturnUrl { get; set; }

        public string ApiUrl { get; set; }

        public string StateId { get; set; }

        public Guid? ClientId { get; set; }

        public Guid? TenantId { get; set; }
    }
}