using System;

namespace OpenSettings.Models.Responses
{
    public class CreateAppIdentifierMappingResponse
    {
        public int MappingSortOrder { get; set; }

        public Guid AppId { get; set; }

        public CreateAppIdentifierMappingResponseIdentifier Identifier { get; set; }
    }
}