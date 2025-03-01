namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopySettingToRequestBody
    {
        public string TargetAppId { get; set; }

        public CopySettingToRequestBodyIdentifier Identifier { get; set; }
    }
}