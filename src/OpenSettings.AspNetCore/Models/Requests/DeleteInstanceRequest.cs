using Microsoft.AspNetCore.Mvc;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteAppInstanceRequest
    {
        [FromRoute]
        public string AppInstanceId { get; set; }
    }
}