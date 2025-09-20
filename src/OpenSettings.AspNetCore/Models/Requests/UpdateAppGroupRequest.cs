using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class UpdateAppGroupRequest
    {
        [FromRoute]
        public string AppGroupId { get; set; }

        [FromBody]
        public UpdateAppGroupRequestBody Body { get; set; }
    }
}