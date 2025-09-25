namespace OpenSettings.Models.Inputs
{
    public class GetAppConfigurationByAppAndIdentifierInput
    {
        public string AppIdOrSlug { get; set; }

        public string IdentifierIdOrSlug { get; set; }
    }
}