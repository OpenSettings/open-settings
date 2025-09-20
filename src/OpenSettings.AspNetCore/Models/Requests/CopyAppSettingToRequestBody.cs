namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CopyAppSettingToRequestBody
    {
        public string TargetAppId { get; set; }

        public CopySettingToRequestBodyIdentifier Identifier { get; set; }
    }
}