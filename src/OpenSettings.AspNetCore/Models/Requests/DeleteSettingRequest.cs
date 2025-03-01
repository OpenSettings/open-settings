using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DeleteSettingRequest
    {
        [FromRoute]
        public string SettingId { get; set; }

        [FromQuery]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}