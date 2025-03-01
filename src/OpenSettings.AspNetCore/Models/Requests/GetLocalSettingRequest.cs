using Microsoft.AspNetCore.Mvc;
using OpenSettings.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class GetLocalSettingRequest
    {
        [FromRoute]
        public Guid ComputedIdentifier { get; set; }

        [FromQuery, Required]
        public ConfigSource ConfigSource { get; set; }
    }
}