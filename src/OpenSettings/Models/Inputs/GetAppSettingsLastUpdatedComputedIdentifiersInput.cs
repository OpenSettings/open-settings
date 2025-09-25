using System;

namespace OpenSettings.Models.Inputs
{
    public class GetAppSettingsLastUpdatedComputedIdentifiersInput
    {
        public Guid ClientId { get; set; }

        private string _identifierName = string.Empty;

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