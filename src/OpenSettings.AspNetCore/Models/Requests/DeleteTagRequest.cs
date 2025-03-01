using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteTagRequest
    {
        [FromRoute]
        public string TagId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}