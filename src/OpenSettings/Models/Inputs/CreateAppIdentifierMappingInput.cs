using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateAppIdentifierMappingInput
    {
        public Guid AppId { get; set; }

        public SetSortOrderPosition SetSortOrderPosition { get; set; }

        public CreateAppIdentifierMappingInputIdentifier Identifier { get; set; }

        public Guid? UserId { get; set; }
    }
}