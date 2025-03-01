using System;

namespace OpenSettings.Models.Inputs
{
    public class CreateAppIdentifierMappingInput
    {
        public string AppId { get; set; }

        public SetSortOrderPosition SetSortOrderPosition { get; set; }

        public CreateAppIdentifierMappingInputIdentifier Identifier { get; set; }

        public Guid? UserId { get; set; }
    }
}