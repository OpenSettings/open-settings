namespace OpenSettings.Models.Inputs
{
    public class GetGroupedAppDataByAppAndIdentifierInput
    {
        public string AppIdOrSlug { get; set; }

        public string IdentifierIdOrSlug { get; set; }
    }
}