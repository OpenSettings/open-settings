namespace OpenSettings.Models.Inputs
{
    public class GetConfigurationByAppAndIdentifierInput
    {
        public string AppIdOrSlug { get; set; }

        public string IdentifierIdOrSlug { get; set; }
    }
}