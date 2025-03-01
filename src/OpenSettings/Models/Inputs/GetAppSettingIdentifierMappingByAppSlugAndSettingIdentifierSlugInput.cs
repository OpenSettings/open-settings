namespace OpenSettings.Models.Inputs
{
    public class GetAppIdentifierMappingByAppAndIdentifierInput
    {
        public string AppIdOrSlug { get; set; }

        public string IdentifierIdOrSlug { get; set; }
    }
}