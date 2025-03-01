namespace OpenSettings.Models.Responses
{
    public class GetAppIdentifierMappingByAppAndIdentifierResponse
    {
        public int MappingSortOrder { get; set; }

        public string AppId { get; set; }

        public GetAppIdentifierMappingByAppAndIdentifierResponseIdentifier Identifier { get; set; }
    }
}