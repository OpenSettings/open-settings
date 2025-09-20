using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopyAppSettingToRequestBody
    {
        public Guid TargetAppId { get; set; }

        public CopySettingToRequestBodyIdentifier Identifier { get; set; }
    }
}