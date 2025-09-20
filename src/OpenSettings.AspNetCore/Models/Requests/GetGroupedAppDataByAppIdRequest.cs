using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetGroupedAppDataByAppIdRequest
    {
        [FromRoute]
        public string AppId { get; set; }
    }
}