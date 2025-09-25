using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetAppSettingsByAppIdAndIdentifierIdRequest
    {
        [FromRoute]
        public string AppId { get; set; }

        [FromRoute]
        public string IdentifierId { get; set; }
    }
}