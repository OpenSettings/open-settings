using System;

namespace OpenSettings.Models.Inputs
{
    public class GetSettingsLastUpdatedComputedIdentifiersInput
    {
        public Guid ClientId { get; set; }

        private string _identifierName = Constants.DefaultIdentifierName;

        public string IdentifierName
        {
            get => _identifierName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _identifierName = value;
                }
            }
        }

        public DateTime? LastUpdatedOn { get; set; }
    }
}