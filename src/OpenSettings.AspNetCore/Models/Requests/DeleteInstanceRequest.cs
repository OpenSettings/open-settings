using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteInstanceRequest
    {
        [FromRoute]
        public string InstanceId { get; set; }
    }
}