using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopySettingToRequestBodyIdentifier
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}