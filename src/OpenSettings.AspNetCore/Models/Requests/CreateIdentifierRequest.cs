using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateIdentifierRequest
    {
        [FromBody]
        public CreateIdentifierRequestBody Body { get; set; }
    }
}