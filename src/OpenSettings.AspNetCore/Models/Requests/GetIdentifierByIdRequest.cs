using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetIdentifierByIdRequest
    {
        [FromRoute]
        public string IdentifierId { get; set; }
    }
}