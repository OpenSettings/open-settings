using System;
using System.Collections.Generic;

namespace OpenSettings.Models.Inputs
{
    public class FetchAppDataInput
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

        public HashSet<Guid> ComputedIdentifiers { get; set; } = new HashSet<Guid>();

        public bool? StoreInSeparateFile { get; set; }
    }
}