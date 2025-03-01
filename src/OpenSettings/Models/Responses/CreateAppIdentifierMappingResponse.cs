namespace OpenSettings.Models.Responses
{
    public class CreateAppIdentifierMappingResponse
    {
        public int MappingSortOrder { get; set; }

        public string AppId { get; set; }

        public CreateAppIdentifierMappingResponseIdentifier Identifier { get; set; }
    }
}