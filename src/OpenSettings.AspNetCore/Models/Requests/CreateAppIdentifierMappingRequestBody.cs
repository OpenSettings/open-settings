using OpenSettings.Models;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateAppIdentifierMappingRequestBody
    {
        public SetSortOrderPosition SetSortOrderPosition { get; set; }

        public CreateAppIdentifierMappingRequestBodyIdentifier Identifier { get; set; }
    }
}