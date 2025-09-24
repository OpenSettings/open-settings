using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppIdentifierMappingsByAppIdRequest
    {
        [FromRoute]
        public string AppId { get; set; }
    }
}