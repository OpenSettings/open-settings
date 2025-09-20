using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetConfigDataRequest
    {
        [FromRoute]
        public string ConfigName { get; set; }
    }
}