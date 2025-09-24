namespace OpenSettings.Models.Responses
{
    public class GetAppIdentifierMappingsResponseIdentifier
    {
        public string Id { get; set; }

        public int SortOrder { get; set; }

        public GetAppIdentifierMappingsResponseIdentifierAppMapping AppMapping { get; set; }
    }
}