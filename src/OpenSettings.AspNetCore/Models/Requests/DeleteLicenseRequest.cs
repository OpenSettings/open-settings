using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteLicenseRequest
    {
        [FromRoute]
        public string ReferenceId { get; set; }
    }
}