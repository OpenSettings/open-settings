namespace OpenSettings.Models.Inputs
{
    public class GetSettingsByAppAndIdentifierInput
    {
        public string AppIdOrSlug { get; set; }

        public string IdentifierIdOrSlug { get; set; }
    }
}