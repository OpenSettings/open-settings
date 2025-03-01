using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class SaveLicenseRequest
    {
        [FromBody]
        public string LicenseKey { get; set; }
    }
}